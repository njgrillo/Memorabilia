namespace Memorabilia.Application.Features.Services.Gallery.Memorabilia.Rules;

public abstract class GalleryRule
{
    public virtual string AutographTitleText(Domain.Entities.Memorabilia memorabilia)
    {
        return memorabilia.Autographs.Count switch
        {
            0 => string.Empty,
            1 => "Autographed",
            2 => "Dual Signed",
            > 2 => "Multi Signed",
            _ => string.Empty,
        };
    }

    public virtual string EstimatedValueText(Domain.Entities.Memorabilia memorabilia)
    {
        var value = (memorabilia.EstimatedValue ?? 0) + memorabilia.Autographs?.Sum(autograph => autograph?.EstimatedValue ?? 0);

        return $"Estimated Value: {value?.ToString("C") ?? string.Empty}";
    }

    public virtual string ItemTypeText(Domain.Entities.Memorabilia memorabilia)
    {
        return memorabilia.ItemType?.Name ?? string.Empty;
    }

    public virtual string PlayerTeamText(Domain.Entities.Memorabilia memorabilia)
    {
        if (memorabilia.Autographs.Count == 1)
        {
            return memorabilia.Autographs.First().Person.ProfileName;
        }
        else
        {
            return memorabilia.Teams.Count switch
            {
                0 => string.Empty,
                1 => memorabilia.Teams.First().Team.Name,
                > 1 => "Multi Team",
                _ => string.Empty,
            };
        }
    }

    public virtual string SizeText(Domain.Entities.Memorabilia memorabilia)
    {
        return Domain.Constants.Size.Find(memorabilia.Size?.SizeId ?? 0)?.Name ?? string.Empty;
    }
}
