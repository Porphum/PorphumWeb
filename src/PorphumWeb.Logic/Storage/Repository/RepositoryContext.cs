using Microsoft.EntityFrameworkCore;
using PorphumWeb.Logic.Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumWeb.Logic.Storage.Repository;
public sealed class RepositoryContext : IRepositoryContext
{
    private readonly WebContext _webContext;

    public RepositoryContext(WebContext webContext)
    {
        _webContext = webContext ?? throw new ArgumentNullException(nameof(webContext));
    }


    public DbSet<Role> Roles => _webContext.Roles;

    public DbSet<User> Users => _webContext.Users;

    public DbSet<Connection> Connections => _webContext.Connections;

    public void SaveChanges() => _webContext.SaveChanges();
}
