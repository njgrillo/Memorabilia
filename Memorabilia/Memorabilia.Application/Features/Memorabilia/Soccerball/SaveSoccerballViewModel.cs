using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Soccerball;

public class SaveSoccerballViewModel : MemorabiliaItemEditViewModel
{
    public SaveSoccerballViewModel() 
    {
        BrandId = Brand.Nike.Id;
        GameStyleTypeId = GameStyleType.None.Id;
        LevelTypeId = LevelType.Professional.Id;
        SizeId = Size.Standard.Id;
    }

    public SaveSoccerballViewModel(SoccerballViewModel viewModel)
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

    public override string ImageFileName => Domain.Constants.ImageFileName.Soccerball;

    public override ItemType ItemType => ItemType.Soccerball;

    public override Sport Sport => Sport.Soccer;
}
