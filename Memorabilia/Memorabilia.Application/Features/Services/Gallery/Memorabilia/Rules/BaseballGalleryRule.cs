namespace Memorabilia.Application.Features.Services.Gallery.Memorabilia.Rules;

public class BaseballGalleryRule : GalleryRule, IGalleryRule
{
    public bool Applies(Domain.Constants.ItemType itemType)
    {
        return itemType == Domain.Constants.ItemType.Baseball;
    }

    public override string GetTitle(Domain.Entities.Memorabilia memorabilia)
    {
        return $"{AutographTitleText(memorabilia)} {PlayerTeamText(memorabilia)} {GetBaseballTypeText(memorabilia)} {ItemTypeText(memorabilia)}";
    }

    private static string GetBaseballTypeText(Domain.Entities.Memorabilia memorabilia)
    {
        var type = Domain.Constants.BaseballType.Find(memorabilia.Baseball?.BaseballTypeId ?? 0)?.Name ?? string.Empty;

        return type.Replace("baseball", string.Empty, StringComparison.OrdinalIgnoreCase);
    }
}
