﻿namespace Memorabilia.Application.Features.Services.Gallery.Memorabilia.Rules;

public class PhotoGalleryRule : GalleryRule, IGalleryRule
{
    public bool Applies(Domain.Constants.ItemType itemType)
    {
        return itemType == Domain.Constants.ItemType.Photo;
    }

    public override string AutographTitleText(Domain.Entities.Memorabilia memorabilia)
    {
        return memorabilia.Autographs.Count switch
        {
            0 => string.Empty,
            1 => "Autographed",
            > 1 => "Multi Signed",
            _ => string.Empty,
        };
    }

    public override string GetTitle(Domain.Entities.Memorabilia memorabilia)
    {
        return $"{AutographTitleText(memorabilia)} {PlayerTeamText(memorabilia)} {SizeText(memorabilia)} {ItemTypeText(memorabilia)}";
    }
}
