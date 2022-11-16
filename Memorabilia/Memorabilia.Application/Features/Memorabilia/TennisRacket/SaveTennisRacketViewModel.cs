using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.TennisRacket;

public class SaveTennisRacketViewModel : MemorabiliaItemEditViewModel
{
    public SaveTennisRacketViewModel() 
    { 
        BrandId = Brand.Nike.Id;
        GameStyleTypeId = GameStyleType.None.Id;
        LevelTypeId = LevelType.Professional.Id;
        SizeId = Size.Standard.Id;
    }

    public SaveTennisRacketViewModel(TennisRacketViewModel viewModel)
    {
        BrandId = viewModel.Brand.BrandId;
        GameDate = viewModel.Game?.GameDate;
        GameStyleTypeId = viewModel.Game?.GameStyleTypeId ?? 0;
        LevelTypeId = viewModel.Level.LevelTypeId;
        MemorabiliaId = viewModel.MemorabiliaId;
        SizeId = viewModel.Size.SizeId;

        if (viewModel.People.Any())
            Person = new SavePersonViewModel(new PersonViewModel(viewModel.People.First().Person));
    }

    public override string ImageFileName => Domain.Constants.ImageFileName.TennisRacket;

    public override ItemType ItemType => ItemType.TennisRacket;

    public override Sport Sport => Sport.Tennis;
}
