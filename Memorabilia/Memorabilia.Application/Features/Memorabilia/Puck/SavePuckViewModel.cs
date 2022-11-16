using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Puck;

public class SavePuckViewModel : MemorabiliaItemEditViewModel
{
    public SavePuckViewModel() 
    { 
        BrandId = Brand.CCM.Id;
        GameStyleTypeId = GameStyleType.None.Id;
        LevelTypeId = LevelType.Professional.Id;
        SizeId = Size.Standard.Id;
    }

    public SavePuckViewModel(PuckViewModel viewModel)
    {
        BrandId = viewModel.Brand.BrandId;
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

    public override bool DisplayGameDate => GameStyleType.IsGameWorthly(GameStyleType) && DisplayGameStyleType;

    public override bool DisplayGameStyleType => SizeId == Size.Standard.Id;

    public override string ImageFileName => Domain.Constants.ImageFileName.Puck;

    public override ItemType ItemType => ItemType.Puck;

    public override Sport Sport => Sport.Hockey;

    public override SportLeagueLevel SportLeagueLevel => SportLeagueLevel.NationalHockeyLeague;
}
