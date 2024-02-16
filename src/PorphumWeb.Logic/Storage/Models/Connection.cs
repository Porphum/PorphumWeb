namespace PorphumWeb
{
    public partial class Connection
    {
        public string KeyId { get; set; } = null!;
        public string DbName { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
