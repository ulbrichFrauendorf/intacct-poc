using Newtonsoft.Json;

namespace SageIntacctDevelopment.Models.PdfInvoice;

public class OrderEntryDocumentPdfResult
{
    [JsonProperty("sodocument")]
    public OrderEntryDocumentPdf OrderEntryDocumentPdf { get; set; }
}