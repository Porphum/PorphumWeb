﻿using PorphumReferenceBook.Logic.Models.Client;
using PorphumSales.Logic.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumSales.Logic.Models.Document;

public class DocumentHeader
{
    public IMappable<Client> Who { get; }

    public IMappable<Client> With { get; }
}
