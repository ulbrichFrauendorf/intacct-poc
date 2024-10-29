using Newtonsoft.Json;

namespace SageIntacctDevelopment.Models.AccountsReceivable;

public class ArInvoiceResult
{
    [JsonProperty("arInvoice")]
    public ArInvoice ArInvoice { get; set; }
}