using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Shoe;

public class SaveShoeViewModel : MemorabiliaItemEditViewModel
{
    public SaveShoeViewModel() 
    {
        BrandId = Brand.Nike.Id;
        GameStyleTypeId = GameStyleType.None.Id;
        LevelTypeId = LevelType.Professional.Id;
    }

    public SaveShoeViewModel(ShoeViewModel viewModel)
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

    public override string ImageFileName => Constant.ImageFileName.Shoe;

    public override ItemType ItemType => ItemType.Shoe;
}
