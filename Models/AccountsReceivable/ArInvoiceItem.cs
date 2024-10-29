using Newtonsoft.Json;

namespace SageIntacctDevelopment.Models.AccountsReceivable;

public class ArInvoiceItem
{
    [JsonProperty("recordNo")]
    public string RecordNo { get; set; }

    [JsonProperty("recordKey")]
    public string RecordKey { get; set; }

    [JsonProperty("accountKey")]
    public string AccountKey { get; set; }

    [JsonProperty("accountNo")]
    public string AccountNo { get; set; }

    [JsonProperty("offsetAccountKey")]
    public string OffsetAccountKey { get; set; }

    [JsonProperty("offsetGlAccountNo")]
    public string OffsetGlAccountNo { get; set; }

    [JsonProperty("amount")]
    public string Amount { get; set; }

    [JsonProperty("lineItem")]
    public string LineItem { get; set; }

    [JsonProperty("currency")]
    public string Currency { get; set; }

    [JsonProperty("baseCurr")]
    public string BaseCurr { get; set; }

    [JsonProperty("totalPaid")]
    public string TotalPaid { get; set; }

    [JsonProperty("parentEntry")]
    public string ParentEntry { get; set; }

    [JsonProperty("state")]
    public string State { get; set; }
}