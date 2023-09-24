using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumSales.Logic.Models.Document;

/// <summary xml:lang="ru">
/// Состояние для документов.
/// </summary>
public enum DocumentState
{
    Unknown = 0,
    Created = 1,
    Filled = 2,
    Complete = 3
}
