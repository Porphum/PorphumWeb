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
    /// <summary xml:lang="ru">
    /// Документ заполняется.
    /// </summary>
    Fill = 0,
    
    /// <summary xml:lang="ru">
    /// Документ проведён.
    /// </summary>
    Complete = 1,

    /// <summary xml:lang="ru">
    /// Ошибка загрузки.
    /// </summary>
    MapError = 2,


}
