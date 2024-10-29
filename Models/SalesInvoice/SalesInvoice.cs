using Newtonsoft.Json;

namespace SageIntacctDevelopment.Models.SalesInvoice;

public class SalesInvoice
{
    [JsonProperty("CustVendId")]
    public string CustVendId { get; set; }

    [JsonProperty("CustVendName")]
    public string CustVendName { get; set; }

    [JsonProperty("DocId")]
    public string DocId { get; set; }

    [JsonProperty("DocNo")]
    public string DocNo { get; set; }

    [JsonProperty("WhenCreated")]
    public string WhenCreated { get; set; }

    [JsonProperty("WhenDue")]
    public string WhenDue { get; set; }

    [JsonProperty("RecordNo")]
    public string RecordNo { get; set; }

    [JsonProperty("Term.Name")]
    public string TermName { get; set; }

    [JsonProperty("ProjectKey")]
    public string ProjectKey { get; set; }

    [JsonProperty("Project")]
    public string Project { get; set; }

    [JsonProperty("Message")]
    public string Message { get; set; }

    [JsonProperty("BaseCurr")]
    public string BaseCurr { get; set; }

    [JsonProperty("Currency")]
    public string Currency { get; set; }

    [JsonProperty("ExchRateDate")]
    public string ExchRateDate { get; set; }

    [JsonProperty("SubTotal")]
    public string SubTotal { get; set; }

    [JsonProperty("Total")]
    public string Total { get; set; }

    [JsonProperty("TotalPaid")]
    public string TotalPaid { get; set; }

    [JsonProperty("TotalEntered")]
    public string TotalEntered { get; set; }

    [JsonProperty("TotalDue")]
    public string TotalDue { get; set; }

    [JsonProperty("CreatedFrom")]
    public string CreatedFrom { get; set; }

    [JsonProperty("State")]
    public string State { get; set; }

    [JsonProperty("Closed")]
    public string Closed { get; set; }

    [JsonProperty("AuWhenCreated")]
    public string AuWhenCreated { get; set; }

    [JsonProperty("CreatedBy")]
    public string CreatedBy { get; set; }

    [JsonProperty("ModifiedBy")]
    public string ModifiedBy { get; set; }

    [JsonProperty("WhenModified")]
    public string WhenModified { get; set; }

    [JsonProperty("Status")]
    public string Status { get; set; }

    [JsonProperty("PoNumber")]
    public string PoNumber { get; set; }

    [JsonProperty("VendorDocNo")]
    public string VendorDocNo { get; set; }

    [JsonProperty("DocParId")]
    public string DocParId { get; set; }

    [JsonProperty("DocParKey")]
    public string DocParKey { get; set; }

    [JsonProperty("DocParClass")]
    public string DocParClass { get; set; }

    [JsonProperty("Note")]
    public string Note { get; set; }

    [JsonProperty("ShipVia")]
    public string ShipVia { get; set; }

    [JsonProperty("User")]
    public string User { get; set; }

    [JsonProperty("CreatedUser")]
    public string CreatedUser { get; set; }
}