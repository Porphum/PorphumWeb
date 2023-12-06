namespace PorphumSales.Logic.Storage.Models;

/// <summary xml:lang="ru">
/// Модель хранилища документа.
/// </summary>
public class Document
{
    /// <summary xml:lang="ru">
    /// Идентификатор документа.
    /// </summary>
    public long Id { get; set; }

    /// <summary xml:lang="ru">
    /// Номер документа.
    /// </summary>
    public int Number { get; set; }

    /// <summary xml:lang="ru">
    /// Дата документа.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary xml:lang="ru">
    /// Идентификатор клиента кто.
    /// </summary>
    public long ClientWhoId { get; set; }

    /// <summary xml:lang="ru">
    /// Идентификатор клиента с кем.
    /// </summary>
    public long ClientWithId { get; set; }

    /// <summary xml:lang="ru">
    /// Идентификатор типа документа.
    /// </summary>
    public DocumentTypeId TypeId { get; set; }

    /// <summary xml:lang="ru">
    /// Идентификатор статуса документа.
    /// </summary>
    public DocumentStateId StatusId { get; set; }

    /// <summary xml:lang="ru">
    /// Позиции в документе.
    /// </summary>
    public virtual ICollection<DocumentsRow> DocumentsRows { get; set; } = new HashSet<DocumentsRow>();
}
