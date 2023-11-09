namespace PorphumSales.Logic.Storage.Models;

/// <summary xml:lang="ru">
/// Модель хранилища для конфига для документов.
/// </summary>
public class DocumentConfig
{
    /// <summary xml:lang="ru">
    /// Идентификатор конфига.
    /// </summary>
    public short Id { get; set; }

    /// <summary xml:lang="ru">
    /// Идентификатор клиента, от чьего имени составляются документы.
    /// </summary>
    public long MasterId { get; set; }
}
