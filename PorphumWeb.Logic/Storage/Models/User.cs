namespace PorphumWeb.Logic.Storage.Models;

public partial class User
{
    public long Id { get; set; }
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;

    public virtual ICollection<Role> Roles { get; set; } = new HashSet<Role>();
}
