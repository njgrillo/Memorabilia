using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Bobblehead;

public class SaveBobbleheadViewModel : SaveItemViewModel
{
    public SaveBobbleheadViewModel() { }

    public SaveBobbleheadViewModel(BobbleheadViewModel viewModel)
    {
        BrandId = viewModel.Brand.BrandId;
        HasBox = viewModel.Bobblehead?.HasBox ?? false;
        LevelTypeId = viewModel.Level.LevelTypeId;
        MemorabiliaId = viewModel.MemorabiliaId;
        SizeId = viewModel.Size.SizeId;
        SportId = viewModel.Sports.Select(x => x.SportId).FirstOrDefault();
        Year = viewModel.Bobblehead?.Year;

        if (viewModel.People.Any())
            Person = new SavePersonViewModel(new PersonViewModel(viewModel.People.First().Person));

        if (viewModel.Teams.Any())
            Team = new SaveTeamViewModel(new TeamViewModel(viewModel.Teams.First().Team));
    }

    public override string BackNavigationPath => $"Memorabilia/{EditModeType.Update.Name}/{MemorabiliaId}";

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
    public int BrandId { get; set; } = Brand.None.Id;

    public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

    public override string ExitNavigationPath => "Memorabilia/Items";

    public bool HasBox { get; set; }

    public override string ImageFileName => Domain.Constants.ImageFileName.Bobblehead;

    public override ItemType ItemType => ItemType.Bobble;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Level is required.")]
    public int LevelTypeId { get; set; } = LevelType.Professional.Id;
   
    public SavePersonViewModel Person { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
    public int SizeId { get; set; } = Size.Standard.Id;

    public Sport Sport => Sport.Find(SportId);

    public int SportId { get; set; }

    public SaveTeamViewModel Team { get; set; }

    public int? Year { get; set; }
}
