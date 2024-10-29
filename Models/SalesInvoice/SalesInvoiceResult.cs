using Newtonsoft.Json;

namespace SageIntacctDevelopment.Models.SalesInvoice;

public class SalesInvoiceResult
{
    [JsonProperty("sodocument")]
    public SalesInvoice SalesInvoice { get; set; }
}