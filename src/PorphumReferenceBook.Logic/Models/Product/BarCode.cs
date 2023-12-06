using System.Text.RegularExpressions;

namespace PorphumReferenceBook.Logic.Models.Product;

/// <summary xml:lang="ru">
/// ����� �����-���� ��������.
/// </summary>
public sealed class BarCode
{
    /// <summary xml:lang="ru">
    /// ������ �������� �����-����.
    /// </summary>
    public static readonly string BARCODE_PATTERN = @".*";

    /// <summary xml:lang="ru">
    /// ������ ��������� ������ <see cref="BarCode"/>.
    /// </summary>
    /// <param name="value" xml:lang="ru">�������� �����-����.</param>
    /// <exception cref="ArgumentException" xml:lang="ru">
    /// ���� <paramref name="value"/> - �� ������������� �������.
    /// </exception>
    public BarCode(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, BARCODE_PATTERN))
        {
            throw new ArgumentException(
                $"Given {nameof(Value)} of {nameof(BarCode)} " +
                $"does not match with required pattern.",
                nameof(value)
            );
        }

        Value = value;
    }

    /// <summary xml:lang="ru">
    /// �������� �����-����.
    /// </summary>
    public string Value { get; }
}
