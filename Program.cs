namespace SageIntacctDevelopment;

class Program
{
    static async Task Main(string[] args)
    {
        const string senderId = "";
        const string senderPassword = "";
        const string userId = "";
        const string userPassword = "";
        const string companyId = "";
        const string entityId = "";

        var uploader = new IntacctInvoiceUploader(senderId, senderPassword, userId, userPassword, companyId, entityId);
        var downloader = new IntacctInvoiceDownloader(senderId, senderPassword, userId, userPassword, companyId, entityId);
        
        try
        {
            await uploader.UploadInvoice();
            await downloader.DownloadInvoice("Sales Invoice-SIN35803");
            Console.WriteLine("Invoice uploaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}