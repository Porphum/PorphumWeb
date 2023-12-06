using General.Models.Query;
using Microsoft.EntityFrameworkCore;
using PorphumReferenceBook.Logic.Abstractions.Storage;
using PorphumReferenceBook.Logic.Abstractions.Storage.Repository;
using PorphumReferenceBook.Logic.Models.Client;
using PorphumReferenceBook.Logic.Models.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumReferenceBook.Logic.Storage.Repository;

using TClient = Models.Client;

public sealed class ClientsQueryRepository : BaseQueryRepository<Client, TClient>, IClientsQueryRepository
{
    private readonly IRepositoryContext _context;

    public ClientsQueryRepository(IRepositoryContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    protected override Client ConvertFromStorage(TClient storage) => storage.ConvertToModel();

    protected override IQueryable<TClient> GetInitQuery() => _context.Clients
        .OrderBy(x => x.Id)
        .AsNoTrackingWithIdentityResolution()
        .Include(x => x.Info);
}
