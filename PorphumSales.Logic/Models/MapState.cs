using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumSales.Logic.Models;

public enum MapState
{
    Init = 0,
    MapError = 1,
    LoadError = 2, // todo
    Success = 3
}
