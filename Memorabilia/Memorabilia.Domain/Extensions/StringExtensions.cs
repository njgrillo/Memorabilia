namespace Memorabilia.Domain.Extensions;

public static class StringExtensions
{
    public static int[] ToIntArray(this string value)
    {
        if (value.IsNullOrEmpty())
            return Array.Empty<int>();

        var results = new List<int>();

        if (value.IndexOf(",") > -1)
        {
            var items = value.Split(',');

            foreach (var item in items)
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
    {
        return new string(value.SelectMany((c, i) => i > 0 && char.IsUpper(c) ? new[] { ' ', c } : new[] { c }).ToArray());
    }

    private static int[] SplitByHyphen(string value)
    {
        var results = new List<int>();
        var range = value.Split("-");
        var startYear = range[0].Trim().ToInt32();
        var endYear = range[1].Trim().ToInt32();
        var length = endYear - startYear + 1;

        foreach (var rangeItem in Enumerable.Range(startYear, length))
        {
            results.Add(rangeItem);
        }

        return results.ToArray();
    }
}
