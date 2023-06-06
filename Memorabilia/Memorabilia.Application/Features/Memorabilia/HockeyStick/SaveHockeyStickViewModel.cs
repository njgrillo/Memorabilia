using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.HockeyStick;

public class SaveHockeyStickViewModel : MemorabiliaItemEditViewModel
{
    public SaveHockeyStickViewModel()
    { 
        BrandId = Brand.CCM.Id;
        GameStyleTypeId = GameStyleType.None.Id;
        LevelTypeId = LevelType.Professional.Id;
        SizeId = Size.Full.Id;
    }

    public SaveHockeyStickViewModel(HockeyStickViewModel viewModel)
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

    public override bool DisplayGameDate 
        => (GameStyleType?.IsGameWorthly() ?? false) && 
           DisplayGameStyleType;

    public override bool DisplayGameStyleType 
        => SizeId == Size.Full.Id;

    public override string ImageFileName 
        => Constant.ImageFileName.HockeyStick;

    public override ItemType ItemType 
        => ItemType.HockeyStick;

    public override Sport Sport 
        => Sport.Hockey;

    public override SportLeagueLevel SportLeagueLevel 
        => SportLeagueLevel.NationalHockeyLeague;
}
