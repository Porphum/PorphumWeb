namespace PorphumWeb.Logic.Storage.Models;

public partial class Role
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
}
