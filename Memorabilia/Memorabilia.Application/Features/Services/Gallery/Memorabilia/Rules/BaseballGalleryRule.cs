﻿namespace Memorabilia.Application.Features.Services.Gallery.Memorabilia.Rules;

public class BaseballGalleryRule : GalleryRule, IGalleryRule
{
    public bool Applies(Constant.ItemType itemType)
    {
        return itemType == Constant.ItemType.Baseball;
    }

    public override string GetTitle(Entity.Memorabilia memorabilia)
    {
        return $"{AutographTitleText(memorabilia)} {PlayerTeamText(memorabilia)} {GetBaseballTypeText(memorabilia)} {ItemTypeText(memorabilia)}";
    }

    private static string GetBaseballTypeText(Entity.Memorabilia memorabilia)
    {
        var type = Constant.BaseballType.Find(memorabilia.Baseball?.BaseballTypeId ?? 0)?.Name ?? string.Empty;

        return type.Replace("baseball", string.Empty, StringComparison.OrdinalIgnoreCase);
    }
}
