using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumSales.Logic.Models.Document;

/// <summary xml:lang="ru">
/// Тип документов.
/// </summary>
public enum DocumentType
{
    /// <summary xml:lang="ru">
    /// Нет типа.
    /// </summary>
    None = 0,

    /// <summary xml:lang="ru">
    /// Приходная накладная.
    /// </summary>
    Prihod = 1,

    /// <summary xml:lang="ru">
    /// Расходная накладная.
    /// </summary>
    Rashod = 2
}
