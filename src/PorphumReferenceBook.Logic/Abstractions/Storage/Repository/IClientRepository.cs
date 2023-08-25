using General.Abstractions.Models;
using General.Abstractions.Storage;
using PorphumReferenceBook.Logic.Models.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumReferenceBook.Logic.Abstractions.Storage.Repository;

/// <summary>
/// 
/// </summary>
public interface IClientRepository : 
    IKeyableRepository<Client, long>, 
    IKeyableRepositoryWithModifiableLoad<Client, ClientIdentityInfo, long>
{
}
