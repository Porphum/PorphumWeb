using General.Abstractions.Models;
using PorphumReferenceBook.Logic.Models.Client;
using PorphumSales.Logic.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumSales.Logic.Models.Document;

public class DocumentHeader
{
    public DocumentHeader(int number, DateTime date, IMappableModel<Client, long> who, IMappableModel<Client, long> with)
    {
        Number = number;
        Date = date;
        Who = who;
        With = with;
    }

    public int Number { get; }

    public DateTime Date { get; }

    public IMappableModel<Client, long> Who { get; }

    public IMappableModel<Client, long> With { get; }
}
