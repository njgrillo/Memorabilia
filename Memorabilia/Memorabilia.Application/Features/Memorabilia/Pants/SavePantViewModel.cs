using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Pants;

public class SavePantViewModel : MemorabiliaItemEditViewModel
{
    public SavePantViewModel() 
    { 
        BrandId = Brand.Nike.Id;
        GameStyleTypeId = GameStyleType.None.Id;
        LevelTypeId = LevelType.Professional.Id;
        SizeId = Size.Large.Id;
    }

    public SavePantViewModel(PantViewModel viewModel)
    {
        BrandId = viewModel.Brand.BrandId;
        GameDate = viewModel.Game?.GameDate;
        GameStyleTypeId = viewModel.Game?.GameStyleTypeId ?? 0;
        LevelTypeId = viewModel.Level.LevelTypeId;
        MemorabiliaId = viewModel.MemorabiliaId;
        SizeId = viewModel.Size.SizeId;
        SportId = viewModel.Sports.Select(sport => sport.SportId).FirstOrDefault();

        if (viewModel.People.Any())
            Person = new SavePersonViewModel(new PersonViewModel(viewModel.People.First().Person));

        if (viewModel.Teams.Any())
            Team = new SaveTeamViewModel(new TeamViewModel(viewModel.Teams.First().Team));
    }

    public override string ImageFileName => Constant.ImageFileName.Pants;

    public override ItemType ItemType => ItemType.Pants;
}
