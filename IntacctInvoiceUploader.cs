using Intacct.SDK.Functions.Common;
using Intacct.SDK.Functions.Common.NewQuery;
using Intacct.SDK.Functions.Common.NewQuery.QueryFilter;
using Intacct.SDK.Functions.Common.NewQuery.QuerySelect;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SageIntacctDevelopment.Models.SalesInvoice;

namespace SageIntacctDevelopment;

using Intacct.SDK;
using System;

internal class IntacctInvoiceUploader(
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
            Object = "SODOCUMENT"
        };
        var lkpresult = await client.Execute(lookup);

        var startDate = new DateTime(2024, 10, 1);
        var endDate = DateTime.Today;
        
        // Invoices With Filter 09/12/2024 12:36:30
        var filterList = new List<IFilter>
        {
            new Filter("WHENCREATED").SetGreaterThanOrEqualTo(startDate.ToString("MM/dd/yyyy")), // Start date
            new Filter("WHENCREATED").SetLessThanOrEqualTo(endDate.ToString("MM/dd/yyyy")) // End date
        };
        var filter = new AndOperator(filterList);

        var selectBuilder = new SelectBuilder();

        var lineFields = selectBuilder.Fields(new[]
        {
            "CustVendId",
            "CustVendName",
            "DocId",
            "DocNo",
            "WhenCreated",
            "WhenDue",
            "RecordNo",
            "Term.Name",
            "ProjectKey",
            "Project",
            "Message",
            "BaseCurr",
            "Currency",
            "ExchRateDate",
            "SubTotal",
            "Total",
            "TotalPaid",
            "TotalEntered",
            "TotalDue",
            "CreatedFrom",
            "State",
            "Closed",
            "AuWhenCreated",
            "CreatedBy",
            "ModifiedBy",
            "WhenModified",
            "Status",
            "PoNumber",
            "VendorDocNo",
            "DocParId",
            "DocParKey",
            "DocParClass",
            "Note",
            "ShipVia",
            "User",
            "CreatedUser"
        }).GetFields();


        var invoiceQuery = new QueryFunction
        {
            FromObject = "SODOCUMENT",
            PageSize = 100,
            Filter = filter,
            SelectFields = lineFields
        };

        var salesInvoicesResponse = await client.Execute(invoiceQuery);
        var salesInvoicesResults = salesInvoicesResponse.Results.Select(result =>
            JsonConvert.DeserializeObject<List<SalesInvoiceResult>>(JsonConvert.SerializeObject(result.Data)));
        
        foreach (var invoices in salesInvoicesResults)
        {
            foreach (var invoic in invoices)
            {

                selectBuilder = new SelectBuilder();
                lineFields = selectBuilder.Fields(new[]
                {
                    "RecordNo", 
                    "itemId", 
                    "itemDesc", 
                    "Unit", 
                    "Quantity", 
                    "Price", 
                    "DiscountPercent", 
                    "Discount", 
                    "Memo", 
                    "DocHdrId",
                    "PercentVal",
                    "TaxAbsVal",
                    "TaxableAmount",
                    "LineTotal",
                    "Total"
                }).GetFields();

                var lineQuery = new QueryFunction()
                {
                    SelectFields = lineFields,
                    FromObject = "sodocumententry",
                    Filter = new Filter("DOCHDRID").SetEqualTo(invoic.SalesInvoice.DocId)
                };

                var lineResponse = await client.Execute(lineQuery);
                var linesResults = lineResponse.Results.Select(result=>
                    JsonConvert.DeserializeObject<List<SalesInvoiceLineResult>>(JsonConvert.SerializeObject(result.Data))).ToList();

                if (lineResponse.Control.Status.Length > 0)
                {
                    foreach (var lineResult in linesResults)
                    {
                        foreach (var line in lineResult)
                        {
                            Console.WriteLine($"  Item{line.SalesInvoiceLine.Price}");
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