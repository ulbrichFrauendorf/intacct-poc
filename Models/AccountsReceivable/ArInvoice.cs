using Newtonsoft.Json;

namespace SageIntacctDevelopment.Models.AccountsReceivable;

public class ArInvoice
{
    [JsonProperty("recordNo")]
    public string RecordNo { get; set; }

    [JsonProperty("recordId")]
    public string RecordId { get; set; }

    [JsonProperty("contactTaxGroup")]
    public string ContactTaxGroup { get; set; }

    [JsonProperty("state")]
    public string State { get; set; }

    [JsonProperty("customerId")]
    public string CustomerId { get; set; }

    [JsonProperty("customerName")]
    public string CustomerName { get; set; }

    [JsonProperty("custMessage.message")]
    public string CustMessageMessage { get; set; }

    [JsonProperty("docNumber")]
    public string DocNumber { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("whenCreated")]
    public string WhenCreated { get; set; }

    [JsonProperty("whenPosted")]
    public string WhenPosted { get; set; }

    [JsonProperty("whenDiscount")]
    public string WhenDiscount { get; set; }

    [JsonProperty("whenDue")]
    public string WhenDue { get; set; }

    [JsonProperty("whenPaid")]
    public string WhenPaid { get; set; }

    [JsonProperty("baseCurr")]
    public string BaseCurr { get; set; }

    [JsonProperty("currency")]
    public string Currency { get; set; }

    [JsonProperty("totalEntered")]
    public string TotalEntered { get; set; }

    [JsonProperty("totalSelected")]
    public string TotalSelected { get; set; }

    [JsonProperty("totalPaid")]
    public string TotalPaid { get; set; }

    [JsonProperty("totalDue")]
    public string TotalDue { get; set; }

    [JsonProperty("taxSolutionId")]
    public string TaxSolutionId { get; set; }

    [JsonProperty("supDocId")]
    public string SupDocId { get; set; }
}