using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Pylon;

public class SavePylonViewModel : MemorabiliaItemEditViewModel
{
    public SavePylonViewModel() 
    {
        GameStyleTypeId = GameStyleType.None.Id;
        LevelTypeId = LevelType.Professional.Id;
        SizeId = Size.Standard.Id;
    }

    public SavePylonViewModel(PylonViewModel viewModel)
    {
        GameDate = viewModel.Game?.GameDate;
        GameStyleTypeId = viewModel.Game?.GameStyleTypeId ?? 0;
        LevelTypeId = viewModel.Level.LevelTypeId;
        MemorabiliaId = viewModel.MemorabiliaId;
        SizeId = viewModel.Size.SizeId;

        if (viewModel.Teams.Any())
            Team = new SaveTeamViewModel(new TeamViewModel(viewModel.Teams.First().Team));
    }

    public override string ImageFileName => Domain.Constants.ImageFileName.Pylon;

    public override ItemType ItemType => ItemType.Pylon;

    public override Sport Sport => Sport.Tennis;

    public override SportLeagueLevel SportLeagueLevel => SportLeagueLevel.NationalFootballLeague;
}
