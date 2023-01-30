using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Tennisball;

public class SaveTennisballViewModel : MemorabiliaItemEditViewModel
{
    public SaveTennisballViewModel() 
    { 
        BrandId = Brand.Wilson.Id;
        GameStyleTypeId = GameStyleType.None.Id;
        LevelTypeId = LevelType.Professional.Id;
        SizeId = Size.Standard.Id;
    }

    public SaveTennisballViewModel(TennisballViewModel viewModel)
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

    public override string ImageFileName => Domain.Constants.ImageFileName.Tennisball;

    public override ItemType ItemType => ItemType.Tennisball;

    public override Sport Sport => Sport.Tennis;
}
