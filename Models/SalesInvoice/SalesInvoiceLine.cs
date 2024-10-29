using Newtonsoft.Json;

namespace SageIntacctDevelopment.Models.SalesInvoice;

public class SalesInvoiceLine
{
    [JsonProperty("RecordNo")]
    public string RecordNo { get; set; }

    [JsonProperty("itemId")]
    public string ItemId { get; set; }

    [JsonProperty("itemDesc")]
    public string ItemDesc { get; set; }

    [JsonProperty("Unit")]
    public string Unit { get; set; }

    [JsonProperty("Quantity")]
    public string Quantity { get; set; }

    [JsonProperty("Price")]
    public string Price { get; set; }

    [JsonProperty("DiscountPercent")]
    public string DiscountPercent { get; set; }

    [JsonProperty("Discount")]
    public string Discount { get; set; }

    [JsonProperty("Memo")]
    public string Memo { get; set; }

    [JsonProperty("DocHdrId")]
    public string DocHdrId { get; set; }

    [JsonProperty("PercentVal")]
    public string PercentVal { get; set; }

    [JsonProperty("TaxAbsVal")]
    public string TaxAbsVal { get; set; }

    [JsonProperty("TaxableAmount")]
    public string TaxableAmount { get; set; }

    [JsonProperty("LineTotal")]
    public string LineTotal { get; set; }

    [JsonProperty("Total")]
    public string Total { get; set; }
}