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
    Init = 0,

    /// <summary xml:lang="ru">
    /// Документ заполняется.
    /// </summary>
    Fill = 1,
    
    /// <summary xml:lang="ru">
    /// Документ проведён.
    /// </summary>
    Complete = 2,

    /// <summary xml:lang="ru">
    /// Ошибка загрузки.
    /// </summary>
    HeaderMapError = 3,

    FillMapError = 4,

    ProductLimitError = 4
}
