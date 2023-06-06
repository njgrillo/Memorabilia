using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Golfball;

public class SaveGolfballViewModel : MemorabiliaItemEditViewModel
{
    public SaveGolfballViewModel()
    {
        BrandId = Brand.Titleist.Id;
        GameStyleTypeId = GameStyleType.None.Id;
        LevelTypeId = LevelType.Professional.Id;
        SizeId = Size.Standard.Id;
    }

    public SaveGolfballViewModel(GolfballViewModel viewModel)
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

    public override bool DisplayGameDate 
        => (GameStyleType?.IsGameWorthly() ?? false) && 
           DisplayGameStyleType;

    public override bool DisplayGameStyleType 
        => SizeId == Size.Standard.Id;

    public override string ImageFileName
        => Constant.ImageFileName.Golfball;

    public override ItemType ItemType 
        => ItemType.Golfball;

    public override Sport Sport 
        => Sport.Golf;
}
