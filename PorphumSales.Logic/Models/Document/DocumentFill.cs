﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumSales.Logic.Models.Document;

public class DocumentFill
{
    IReadOnlySet<DocumentFillRow> Rows { get; }
}