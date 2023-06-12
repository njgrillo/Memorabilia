namespace Memorabilia.Application.Features.Services.Gallery.Memorabilia.Rules;

public class HelmetGalleryRule : GalleryRule, IGalleryRule
{
    public bool Applies(Constant.ItemType itemType)
        => itemType == Constant.ItemType.Helmet;

    public override string AutographTitleText(Entity.Memorabilia memorabilia)
        => memorabilia.Autographs.Count switch
            {
                0 => Constant.Size.Find(memorabilia.Size?.SizeId ?? 0) == Constant.Size.Full
                        ? Constant.HelmetQualityType.Find(memorabilia.Helmet?.HelmetQualityTypeId ?? 0)?.Name ?? string.Empty
                        : string.Empty,
                1 => "Autographed",
                2 => "Dual Signed",
                > 2 => "Multi Signed",
                _ => string.Empty,
            };

    public override string GetTitle(Entity.Memorabilia memorabilia)
        => $"{AutographTitleText(memorabilia)} {PlayerTeamText(memorabilia)} {SizeText(memorabilia)} {ItemTypeText(memorabilia)}";
}
