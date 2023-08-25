using General.Abstractions.Models;
using General.Models;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace PorphumReferenceBook.Logic.Models.Client;

public class Client : BaseLoadableModel<ClientIdentityInfo>, IKeyable<long>
{
    public static readonly string CLIENT_NAME_PATTERN = @".*";

    private string _name = null!;

    public Client(long key, string name)
    {
        Key = key;
        Name = name;
    }

    public long Key { get; }

    public string Name 
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException();

            if (!Regex.IsMatch(value, CLIENT_NAME_PATTERN))
                throw new ArgumentException();

            _name = value;
        }
    }

    public ClientIdentityInfo? IdentityInfo { get; private set;}

    protected override void LoadParam(ClientIdentityInfo? param)
    {
        IdentityInfo = param ?? throw new ArgumentNullException();
    }
}
