using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.WristBand;

public class SaveWristBandViewModel : MemorabiliaItemEditViewModel
{
    public SaveWristBandViewModel() 
    {
        BrandId = Brand.Rawlings.Id;
        GameStyleTypeId = GameStyleType.None.Id;
        LevelTypeId = LevelType.Professional.Id;
    }

    public SaveWristBandViewModel(WristBandViewModel viewModel)
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

    public override string ImageFileName => Domain.Constants.ImageFileName.WristBand;

    public override ItemType ItemType => ItemType.WristBand;
}
