using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Abstractions.Storage;

public interface IBaseRepositoryContext
{
    /// <summary xml:lang = "ru">
    /// Сохраняет текущие изменения.
    /// </summary>
    public void SaveChanges();
}
