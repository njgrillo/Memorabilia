namespace Memorabilia.Domain.Extensions;

public static class StringExtensions
{
    public static bool TryParse(this string value, out int result)
    {
        bool isValid = int.TryParse(value, out result);

        return isValid;
    }

    public static bool IsNullOrEmpty(this string value)
        => string.IsNullOrEmpty(value);

    public static bool ToBoolean(this string value)
        => !value.IsNullOrEmpty() && 
           Convert.ToBoolean(value.ToInt32());

    public static byte[] ToByte(this string value)
    {
        if (value == null)
            return null;

        var newByte = new byte[value.Length / 2];

        for (var i = 0; i < value.Length / 2; i++)
        {
            newByte[i] = Convert.ToByte(value.Substring(2 * i, 2), 16);
        }

        return newByte;
    }

    public static string ToImageData(this string path)
    {
        if (!File.Exists(path))
            return string.Empty;

        return $"data:image/jpg;base64,{Convert.ToBase64String(File.ReadAllBytes(path))}";
    }

    public static int ToInt32(this string value)
        => !value.IsNullOrEmpty() 
        ? Convert.ToInt32(value) 
        : 0;

    public static int[] ToIntArray(this string value)
    {
        if (value.IsNullOrEmpty())
            return Array.Empty<int>();

        var results = new List<int>();

        if (value.IndexOf(",") > -1)
        {
            string[] items = value.Split(',');

            foreach (string item in items)
            {
                if (item.IndexOf("-") > -1)
                {
                    results.AddRange(SplitByHyphen(item));
                }
                else
                {
                    results.Add(item.Trim().ToInt32());
                }
            }
        }
        else
        {
            if (value.IndexOf("-") > -1)
            {
                results.AddRange(SplitByHyphen(value));
            }
            else
            {
                results.Add(value.Trim().ToInt32());
            }
        }

        return results.ToArray();
    }

    public static string ToPlural(this string value)
    {
        if (value.EndsWith("h"))
            return $"{value}es";

        if (value.EndsWith("y"))
            return $"{value[..^1]}ies";

        return $"{value}s";
    }

    public static string ToSentence(this string value)
        => new(value.SelectMany((c, i) => i > 0 && char.IsUpper(c) ? new[] { ' ', c } : new[] { c })
                  .ToArray());

    private static int[] SplitByHyphen(string value)
    {
        var results = new List<int>();
        string[] range = value.Split("-");
        int startYear = range[0].Trim().ToInt32();
        int endYear = range[1].Trim().ToInt32();
        int length = endYear - startYear + 1;

        foreach (int rangeItem in Enumerable.Range(startYear, length))
        {
            results.Add(rangeItem);
        }

        return results.ToArray();
    }
}
