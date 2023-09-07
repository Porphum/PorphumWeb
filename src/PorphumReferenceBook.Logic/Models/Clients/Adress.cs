using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PorphumReferenceBook.Logic.Models.Clients;

public sealed class Adress
{
    public static readonly string POST_INDEX_PATTERN = @".*";

    public static readonly string CITY_PATTERN = @".*";

    public static readonly string STREET_PATTERN = @".*";

    public static readonly string HOUSE_NUMBER_PATTERN = @".*";

    private string? _postIndex = null;

    private string? _city = null;

    private string? _street = null;

    private string? _houseNumber = null;

    public Adress(string adressString)
    {
        // todo adress parser
    }

    public Adress(string? postIndex, string? city, string? street, string? houseNumber)
    {
        City = city;
        Street = street;
        HouseNumber = houseNumber;
        PostIndex = postIndex;
    }

    public string? PostIndex 
    {
        get => _postIndex;

        set
        {
            if (value is null)
            {
                _postIndex = null;
                return;
            }

            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException();

            if (Regex.IsMatch(value, POST_INDEX_PATTERN))
                throw new ArgumentException();

            _postIndex = value;
        }
    }

    public string? City
    {
        get => _city;

        set
        {
            if (value is null)
            {
                _city = null;
                return;
            }

            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException();

            if (Regex.IsMatch(value, CITY_PATTERN))
                throw new ArgumentException();

            _city = value;
        }
    }

    public string? Street
    {
        get => _street;

        set
        {
            if (value is null)
            {
                _street = null;
                return;
            }

            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException();

            if (Regex.IsMatch(value, STREET_PATTERN))
                throw new ArgumentException();

            _street = value;
        }
    }

    public string? HouseNumber
    {
        get => _houseNumber;

        set
        {
            if (value is null)
            {
                _houseNumber = null;
                return;
            }

            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException();

            if (Regex.IsMatch(value, HOUSE_NUMBER_PATTERN))
                throw new ArgumentException();

            _houseNumber = value;
        }
    }
}
