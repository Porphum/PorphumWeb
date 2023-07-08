using PorphumReferenceBook.Logic.Models.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumSales.Logic.Models.Document;

public class DocumentConfig
{
    public DocumentConfig(Client master)
    {
        Master = master ?? throw new ArgumentNullException();
    }

    public Client Master { get; }
}
