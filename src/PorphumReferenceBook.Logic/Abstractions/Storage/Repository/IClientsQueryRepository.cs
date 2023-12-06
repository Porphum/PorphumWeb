using General.Abstractions.Storage.Query;
using PorphumReferenceBook.Logic.Models.Client;

namespace PorphumReferenceBook.Logic.Abstractions.Storage.Repository;

using TClient = Logic.Storage.Models.Client;

public interface IClientsQueryRepository : IQueryableRepository<Client, TClient>
{
}
