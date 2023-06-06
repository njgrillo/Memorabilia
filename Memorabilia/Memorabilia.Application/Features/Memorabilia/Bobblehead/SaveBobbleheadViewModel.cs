using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Bobblehead;

public class SaveBobbleheadViewModel : MemorabiliaItemEditViewModel
{
    public SaveBobbleheadViewModel()
    {
        BrandId = Brand.None.Id;
        LevelTypeId = LevelType.Professional.Id;
        SizeId = Size.Standard.Id;
    }

    public SaveBobbleheadViewModel(BobbleheadViewModel viewModel)
    {
        BrandId = viewModel.Brand.BrandId;
        HasBox = viewModel.Bobblehead?.HasBox ?? false;
        LevelTypeId = viewModel.Level.LevelTypeId;
        MemorabiliaId = viewModel.MemorabiliaId;
        SizeId = viewModel.Size.SizeId;
        SportId = viewModel.Sports.Select(x => x.SportId).FirstOrDefault();
        Year = viewModel.Bobblehead?.Year;

        if (viewModel.People.Any())
            Person = new SavePersonViewModel(new PersonViewModel(viewModel.People.First().Person));

        if (viewModel.Teams.Any())
            Team = new SaveTeamViewModel(new TeamViewModel(viewModel.Teams.First().Team));
    }

    public bool HasBox { get; set; }

    public override string ImageFileName => Constant.ImageFileName.Bobblehead;

    public override ItemType ItemType => ItemType.Bobble;   

    public int? Year { get; set; }
}
