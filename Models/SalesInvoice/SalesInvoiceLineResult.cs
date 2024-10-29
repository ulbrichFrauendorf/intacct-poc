using Newtonsoft.Json;

namespace SageIntacctDevelopment.Models.SalesInvoice;

public class SalesInvoiceLineResult
{
    [JsonProperty("sodocumententry")]
    public SalesInvoiceLine SalesInvoiceLine { get; set; }
}