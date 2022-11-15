using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Basketball;

public class SaveBasketballViewModel : SaveItemViewModel
{
    public SaveBasketballViewModel() { }

    public SaveBasketballViewModel(BasketballViewModel viewModel)
    {
        BasketballTypeId = viewModel.Basketball?.BasketballTypeId ?? 0;
        BrandId = viewModel.Brand.BrandId;
        CommissionerId = viewModel.Commissioner?.CommissionerId ?? 0;
        GameDate = viewModel.Game?.GameDate;
        GameStyleTypeId = viewModel.Game?.GameStyleTypeId ?? 0;
        LevelTypeId = viewModel.Level.LevelTypeId;
        MemorabiliaId = viewModel.MemorabiliaId;
        SizeId = viewModel.Size.SizeId;

        if (viewModel.People.Any())
            Person = new SavePersonViewModel(new PersonViewModel(viewModel.People.First().Person));

        if (viewModel.Teams.Any())
            Team = new SaveTeamViewModel(new TeamViewModel(viewModel.Teams.First().Team));
    }

    public override string BackNavigationPath => $"Memorabilia/{EditModeType.Update.Name}/{MemorabiliaId}";

    public int BasketballTypeId { get; set; } = BasketballType.Official.Id;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
    public int BrandId { get; set; } = Brand.Spalding.Id;

    public int CommissionerId { get; set; }

    public bool DisplayGameDate => GameStyleType.IsGameWorthly(GameStyleType) && DisplayGameStyle;

    public bool DisplayGameStyle => SizeId == Size.Full.Id;

    public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

    public override string ExitNavigationPath => "Memorabilia/Items";

    public DateTime? GameDate { get; set; }

    public GameStyleType GameStyleType => GameStyleType.Find(GameStyleTypeId);

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Game Style Type is required.")]
    public int GameStyleTypeId { get; set; } = GameStyleType.None.Id;

    public override string ImageFileName => Domain.Constants.ImageFileName.Basketball;

    public override ItemType ItemType => ItemType.Basketball;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Level is required.")]
    public int LevelTypeId { get; set; } = LevelType.Professional.Id;

    public SavePersonViewModel Person { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
    public int SizeId { get; set; } = Size.Standard.Id;

    public Sport Sport => Sport.Basketball;

    public SportLeagueLevel SportLeagueLevel => SportLeagueLevel.NationalBasketballAssociation;

    public SaveTeamViewModel Team { get; set; }
}
