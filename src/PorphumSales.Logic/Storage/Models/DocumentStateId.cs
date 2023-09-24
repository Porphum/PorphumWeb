namespace PorphumSales.Logic.Storage.Models;

/// <summary xml:lang="ru">
/// Состояния документа.
/// </summary>
public enum DocumentStateId : short
{
    Unknown = 0,
    Created = 1,
    Filled = 2,
    Complete = 3
}
