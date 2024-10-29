using Intacct.SDK;
using Intacct.SDK.Functions.Common;
using Intacct.SDK.Functions.Common.NewQuery;
using Intacct.SDK.Functions.Common.NewQuery.QueryFilter;
using Intacct.SDK.Functions.Common.NewQuery.QuerySelect;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SageIntacctDevelopment.Models.AccountsReceivable;

namespace SageIntacctDevelopment;

internal class IntacctArInvoiceUploader(
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

    public async Task UploadInvoice()
    {
        var client = new OnlineClient(_clientConfig);

        var lookup = new Lookup(Guid.NewGuid().ToString())
        {
            Object = "arInvoice"
        };
        var lkpresult = await client.Execute(lookup);

        var startDate = new DateTime(2024, 8, 1);
        var endDate = DateTime.Today;

        // Invoices With Filter 09/12/2024 12:36:30
        var filterList = new List<IFilter>
        {
            new Filter("CustomerId").SetEqualTo("ENT008"),
            new Filter("WHENCREATED").SetGreaterThanOrEqualTo(startDate.ToString("MM/dd/yyyy")), // Start date
            new Filter("WHENCREATED").SetLessThanOrEqualTo(endDate.ToString("MM/dd/yyyy")) // End date
        };
        var filter = new AndOperator(filterList);

        var selectBuilder = new SelectBuilder();

        var lineFields = selectBuilder.Fields(new[]
        {
            "recordNo", "recordId", "contactTaxGroup", "state", "customerId", "customerName",
            "custMessage.message", "docNumber", "description", "whenCreated", "whenPosted", "whenDiscount",
            "whenDue", "whenPaid", "baseCurr", "currency", "totalEntered",
            "totalSelected", "totalPaid", "totalDue", "taxSolutionId", "supDocId"
        }).GetFields();


        var invoiceQuery = new QueryFunction
        {
            FromObject = "arInvoice",
            PageSize = 100,
            Filter = filter,
            SelectFields = lineFields
        };

        var arInvoicesResponse = await client.Execute(invoiceQuery);

        var arInvoicesResults = arInvoicesResponse.Results.Select(result =>
            JsonConvert.DeserializeObject<List<ArInvoiceResult>>(JsonConvert.SerializeObject(result.Data)));

        foreach (var invoices in arInvoicesResults)
        {
            foreach (var invoic in invoices)
            {

                selectBuilder = new SelectBuilder();
                lineFields = selectBuilder.Fields(new[]
                {
                    "recordNo", "recordKey","accountNo", "offsetAccountKey", "offsetGlAccountNo", "amount", "lineItem", "currency", "baseCurr", "totalPaid",
                    "parentEntry", "state"
                }).GetFields();

                var lineQuery = new QueryFunction()
                {
                    SelectFields = lineFields,
                    FromObject = "arInvoiceItem",
                    Filter = new Filter("recordKey").SetEqualTo(invoic.ArInvoice.RecordNo)
                };

                var lineResponse = await client.Execute(lineQuery);
                var linesResults = lineResponse.Results.Select(result =>
                    JsonConvert.DeserializeObject<List<ArInvoiceItemResult>>(JsonConvert.SerializeObject(result.Data))).ToList();

                if (lineResponse.Control.Status.Length > 0)
                {
                    foreach (var lineResult in linesResults)
                    {
                        foreach (var line in lineResult)
                        {
                            Console.WriteLine($"  Item{line.ArInvoiceItem.Amount}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Error querying invoice lines");
                }
            }


        }
    }
}