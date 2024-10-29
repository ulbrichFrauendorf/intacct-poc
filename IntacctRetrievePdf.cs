using Intacct.SDK.Functions;
using Intacct.SDK.Xml;

namespace SageIntacctDevelopment;

public class IntacctRetrievePdf(string controlId = null) : AbstractFunction(controlId)
{
    public string ObjectName { get; set; }
    public string DocumentId { get; set; }

    public override void WriteXml(ref IaXmlWriter xml)
    {
        xml.WriteStartElement("function");
        xml.WriteAttribute("controlid", this.ControlId, true);

        xml.WriteStartElement("retrievepdf");
        xml.WriteStartElement(this.ObjectName); // "ARINVOICE" for invoice PDF retrieval
        xml.WriteElement("DOCID", this.DocumentId);

        xml.WriteEndElement(); // ObjectName
        xml.WriteEndElement(); // retrievepdf
        xml.WriteEndElement(); // function
    }
}