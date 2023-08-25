using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumSales.Logic.Storage.Models;

public enum DocumentStatusId : short
{
    Unknown = 0,
    Created = 1,
    Filled = 2,
    Complete = 3
}
