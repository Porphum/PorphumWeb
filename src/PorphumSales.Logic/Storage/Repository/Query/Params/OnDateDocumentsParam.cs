using General.Abstractions.Storage.Query;
using Microsoft.EntityFrameworkCore;
using PorphumSales.Logic.Storage.Models;

namespace PorphumSales.Logic.Storage.Repository.Query.Params;
public class OnDateDocumentsParam : IQueryParam<Document>
{

    private readonly DateTime _date;

    public OnDateDocumentsParam(DateTime date)
    {
        _date = date;
    }

    public IQueryable<Document> ApplyParam(IQueryable<Document> data)
    {
        DateTime dateFrom = _date.Date.Subtract(TimeSpan.FromDays(1));
        DateTime dateTo = _date.Date.AddDays(1);

        return data.Where(x => x.Date > dateFrom).Where(x => x.Date < dateTo);
    }
}
