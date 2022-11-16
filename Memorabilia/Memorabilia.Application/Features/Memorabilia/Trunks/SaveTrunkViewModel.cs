using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Trunks;

public class SaveTrunkViewModel : MemorabiliaItemEditViewModel
{
    public SaveTrunkViewModel() 
    {
        BrandId = Brand.Nike.Id;
        GameStyleTypeId = GameStyleType.None.Id;
        LevelTypeId = LevelType.Professional.Id;
        SizeId = Size.Standard.Id;
    }

    public SaveTrunkViewModel(TrunkViewModel viewModel)
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
    }

    public override string ImageFileName => Domain.Constants.ImageFileName.Trunks;

    public override ItemType ItemType => ItemType.Trunks;
}
