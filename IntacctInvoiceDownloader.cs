using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Intacct.SDK;
using SageIntacctDevelopment.Models.PdfInvoice;

namespace SageIntacctDevelopment;

internal class IntacctInvoiceDownloader(
    string senderId,
    string senderPassword,
    string userId,
    string userPassword,
    string companyId,
    string entityId)
{
    private readonly ClientConfig _clientConfig = new()
    {
        ProfileFile = null,
        ProfileName = null,
        EndpointUrl = null,
        SenderId = senderId,
        SenderPassword = senderPassword,
        // SessionId = Guid.NewGuid().ToString(),
        UserId = userId,
        UserPassword = userPassword,
        Credentials = null,
        Logger = null,
        LogLevel = LogLevel.Trace,
        LogMessageFormatter = null,
        MockHandler = null,
        CompanyId = companyId,
        EntityId = entityId,
    };

    private readonly RequestConfig _requestConfig = new()
    {
        ControlId = Guid.NewGuid().ToString(),
    };

    public async Task DownloadInvoice(string documentId)
    {
        var client = new OnlineClient(_clientConfig);


        // Create a new function request
        var retrievePdf = new IntacctRetrievePdf()
        {
            ObjectName = "SODOCUMENT",
            DocumentId = documentId
        };

        // Execute the function
        var response = await client.Execute(retrievePdf);

        var soDocumentResults = response.Results.Select(result =>
            JsonConvert.DeserializeObject<List<OrderEntryDocumentPdfResult>>(JsonConvert.SerializeObject(result.Data)));

        foreach (var arInvoicesResult in soDocumentResults)
        {
            foreach (var invoicePdfResult in arInvoicesResult)
            {
                var pdf = Convert.FromBase64String(invoicePdfResult.OrderEntryDocumentPdf.Pdfdata);
                File.WriteAllBytes("SOInvoice.pdf", pdf);
            }
        }
    }
}