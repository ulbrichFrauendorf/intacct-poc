using Newtonsoft.Json;

namespace SageIntacctDevelopment.Models.AccountsReceivable;

// Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);

public class ArInvoiceItemResult
{
    [JsonProperty("arInvoiceItem")]
    public ArInvoiceItem ArInvoiceItem { get; set; }
}

