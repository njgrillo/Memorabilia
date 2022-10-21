namespace Memorabilia.Application.Features.Services.Gallery.Memorabilia.Rules;

public class HelmetGalleryRule : GalleryRule, IGalleryRule
{
    public bool Applies(Domain.Constants.ItemType itemType)
    {
        return itemType == Domain.Constants.ItemType.Helmet;
    }

    public string GetDescription(Domain.Entities.Memorabilia memorabilia)
    {
        return string.Empty;
    }

    public string GetSubtitle(Domain.Entities.Memorabilia memorabilia)
    {
        return EstimatedValueText(memorabilia);
    }

    public string GetTitle(Domain.Entities.Memorabilia memorabilia)
    {
        return $"{AutographTitleText(memorabilia)} {PlayerTeamText(memorabilia)} {SizeText(memorabilia)} {ItemTypeText(memorabilia)}";
    }

    public override string AutographTitleText(Domain.Entities.Memorabilia memorabilia)
    {
        return memorabilia.Autographs.Count switch
        {
            0 => Domain.Constants.Size.Find(memorabilia.Size?.SizeId ?? 0) == Domain.Constants.Size.Full 
                    ? Domain.Constants.HelmetQualityType.Find(memorabilia.Helmet?.HelmetQualityTypeId ?? 0)?.Name ?? string.Empty   
                    : string.Empty,
            1 => "Autographed",
            2 => "Dual Signed",
            > 2 => "Multi Signed",
            _ => string.Empty,
        };
    }
}
