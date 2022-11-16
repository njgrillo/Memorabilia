using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Football;

public class SaveFootballViewModel : MemorabiliaItemEditViewModel
{
    public SaveFootballViewModel() 
    { 
        BrandId = Brand.Wilson.Id;
        GameStyleTypeId = GameStyleType.None.Id;
        LevelTypeId = LevelType.Professional.Id;
        SizeId = Size.Full.Id;
    }

    public SaveFootballViewModel(FootballViewModel viewModel)
    {            
        BrandId = viewModel.Brand.BrandId;
        CommissionerId = viewModel.Commissioner.CommissionerId;
        FootballTypeId = viewModel.Football?.FootballTypeId ?? 0;
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

    public int CommissionerId { get; set; }

    public override bool DisplayGameDate => GameStyleType.IsGameWorthly(GameStyleType) && DisplayGameStyleType;

    public override bool DisplayGameStyleType => SizeId == Size.Full.Id;

    public int FootballTypeId { get; set; } = FootballType.Duke.Id;

    public override string ImageFileName => Domain.Constants.ImageFileName.Football;

    public override ItemType ItemType => ItemType.Football;

    public override Sport Sport => Sport.Football;

    public override SportLeagueLevel SportLeagueLevel => SportLeagueLevel.NationalFootballLeague;
}
