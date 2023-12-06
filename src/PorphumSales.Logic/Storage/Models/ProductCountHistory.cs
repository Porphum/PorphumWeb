namespace PorphumSales.Logic.Storage.Models;

public partial class ProductCountHistory
{
    public long HistoryId { get; set; }
    public long ProductId { get; set; }
    public long? DocumentId { get; set; }
    public int Delta { get; set; }
    public DateTime AccurDate { get; set; }
    public string WriteType { get; set; } = null!;

    public virtual Document Document { get; set; } = null!;
}
