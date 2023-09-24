using PorphumReferenceBook.Logic.Models.Client;

namespace PorphumSales.Logic.Models.Document;

public class DocumentConfig
{
    public DocumentConfig(Client master)
    {
        Master = master ?? throw new ArgumentNullException();
    }

    public Client Master { get; }
}
