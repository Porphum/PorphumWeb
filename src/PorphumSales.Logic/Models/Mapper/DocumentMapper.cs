using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumSales.Logic.Models.Mapper;

using General.Abstractions.Models;
using PorphumReferenceBook.Logic.Models.Client;
using PorphumReferenceBook.Logic.Models.Product;
using PorphumSales.Logic.Abstractions.Models;
using PorphumSales.Logic.Models.Document;
using System.Runtime.CompilerServices;

public class DocumentMapper : IMapper<Document>
{
    private readonly IModelMapper<Product, long> _productMapper;
    private readonly IModelMapper<Client, long> _clientMapper;
    
    public DocumentMapper(IModelMapper<Product, long> productMapper, IModelMapper<Client, long> clientMapper)
    {
        _productMapper = productMapper;
        _clientMapper = clientMapper;
    }

    private DocumentHeader MapHeader(DocumentHeader header) 
    {
        var who = _clientMapper.MapEntity(header.Who);
        var with = _clientMapper.MapEntity(header.With);

        return new DocumentHeader(header.Number, header.Date, who, with);
    }

    private DocumentFill MapFill(DocumentFill fill) 
    { 
        var rows = new HashSet<DocumentFillRow>();

        foreach(var row in fill.Rows) 
        {
            rows.Add(new DocumentFillRow(
                _productMapper.MapEntity(row.Product),
                row.Cost,
                row.Qunatity));
        }

        return new DocumentFill(rows);
    }

    public Document Map(Document entity)
    {
        var header = MapHeader(entity.Header);

        var document = new Document(
            entity.Key,
            header,
            entity.Type,
            entity.Status);

        if (entity.IsLoaded)
        {
            var fill = MapFill(entity.Fill!);

            document.Load(fill);
        }

        return document;
    }
}
