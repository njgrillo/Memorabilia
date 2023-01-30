using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.HeadBand;

public class SaveHeadBandViewModel : MemorabiliaItemEditViewModel
{
    public SaveHeadBandViewModel()
    {
        BrandId = Brand.None.Id;
        GameStyleTypeId = GameStyleType.None.Id;
        LevelTypeId = LevelType.Professional.Id;
    }

    public SaveHeadBandViewModel(HeadBandViewModel viewModel)
    {
        BrandId = viewModel.Brand.BrandId;
        GameDate = viewModel.Game?.GameDate;
        GameStyleTypeId = viewModel.Game?.GameStyleTypeId ?? 0;
        LevelTypeId = viewModel.Level.LevelTypeId;
        MemorabiliaId = viewModel.MemorabiliaId;
        SportId = viewModel.Sports.Select(sport => sport.SportId).FirstOrDefault();

        if (viewModel.People.Any())
            Person = new SavePersonViewModel(new PersonViewModel(viewModel.People.First().Person));

        if (viewModel.Teams.Any())
            Team = new SaveTeamViewModel(new TeamViewModel(viewModel.Teams.First().Team));
    }

    public override bool DisplayGameDate => GameStyleType.IsGameWorthly(GameStyleType);

    public override string ImageFileName => Domain.Constants.ImageFileName.HeadBand;

    public override ItemType ItemType => ItemType.HeadBand;
}
