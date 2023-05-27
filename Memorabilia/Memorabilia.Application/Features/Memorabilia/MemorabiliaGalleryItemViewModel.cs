﻿using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia;

public class MemorabiliaGalleryItemViewModel
{
    private readonly Domain.Entities.Memorabilia _memorabilia;

    public MemorabiliaGalleryItemViewModel(Domain.Entities.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
        Autographs = _memorabilia.Autographs.Select(autograph => new AutographGalleryViewModel(autograph));
    }

    public IEnumerable<AutographGalleryViewModel> Autographs { get; set; } = Enumerable.Empty<AutographGalleryViewModel>();

    public string Description => $"Estimated Value: {_memorabilia.EstimatedValue + _memorabilia.Autographs.Sum(autograph => autograph.EstimatedValue)}";

    public string EditNavigationPath => $"/Memorabilia/{EditModeType.Update.Name}/{_memorabilia.Id}";

    public int Id => _memorabilia.Id;

    public string ImageFileName
    {
        get
        {
            var imageFileName = _memorabilia.Images.Any()
                ? _memorabilia.Images.SingleOrDefault(image => image.ImageTypeId == ImageType.Primary.Id)?.FileName ?? Domain.Constants.ImageFileName.ImageNotAvailable
                : Domain.Constants.ImageFileName.ImageNotAvailable;

            return !imageFileName.IsNullOrEmpty() ? imageFileName : Domain.Constants.ImageFileName.ImageNotAvailable;
        }
    }

    public Domain.Entities.Memorabilia Memorabilia => _memorabilia;

    public string PrimaryImageNavigationPath => $"/Memorabilia/Image/{EditModeType.Update.Name}/{Id}";    

    public string Subtitle => string.Empty;

    public string Title
    {
        get
        {
            var sb = new StringBuilder();

            sb.Append($"{(_memorabilia.Autographs.Any() ? "Autographed" : "Unsigned")}");

            if (_memorabilia.ItemType.CanHaveTeam() && _memorabilia.Teams.Any())
                sb.Append($" {string.Join(", ", _memorabilia.Teams.Select(team => team.Team.Name))}");

            if (_memorabilia.ItemType.CanHaveSize() && _memorabilia.ItemType.DisplaySizeInTitles)
                sb.Append($" {Size.Find(_memorabilia.Size.SizeId)?.Name}");

            sb.Append($" {_memorabilia.ItemType.Name}");

            return sb.ToString();
        }
    }

    public string TooltipText => Title;
}
