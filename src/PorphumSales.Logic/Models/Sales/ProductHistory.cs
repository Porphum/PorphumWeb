using General.Abstractions.Models;
using PorphumReferenceBook.Logic.Models.Product;


namespace PorphumSales.Logic.Models.Sales;
public sealed class ProductHistory
{
    public ProductHistory(IMappableModel<Product, long> product, int delta, DateTime accurDate, WriteType writeType = WriteType.Manual, long documentId = 0)
    {
        Product = product ?? throw new ArgumentNullException();
        DocumentId = documentId;
        Delta = delta;
        AccurDate = accurDate;
        WriteType = writeType;
    }

    public string Type => WriteType switch
    {
        WriteType.Manual => "Manualy",
        WriteType.Trigger => DocumentId == 0
            ? "Trigger: Trigger document was deleted"
            : $"Trigger: by Document {DocumentId}",
        _ => throw new NotImplementedException()
    };

    public IMappableModel<Product, long> Product { get; }

    public long DocumentId { get; }
    
    public int Delta { get; }
    
    public DateTime AccurDate { get; }
    
    public WriteType WriteType { get; } 
}
