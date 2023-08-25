using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PorphumReferenceBook.Logic.Models.Clients;

public sealed record class Inn
{
    public static readonly string INN_PATTERN = @".*";

    public Inn(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException();

        if (!Regex.IsMatch(value, INN_PATTERN))
            throw new ArgumentException();

        Value = value;
    }

    public string Value { get; }
}
