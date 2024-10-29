using Newtonsoft.Json;

namespace SageIntacctDevelopment.Models.PdfInvoice;

public class OrderEntryDocumentPdf
{
    [JsonProperty("docid")]
    public string Docid { get; set; }

    [JsonProperty("pdfdata")]
    public string Pdfdata { get; set; }
}