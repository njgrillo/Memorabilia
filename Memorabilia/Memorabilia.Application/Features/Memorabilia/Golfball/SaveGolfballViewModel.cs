using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Golfball;

public class SaveGolfballViewModel : SaveItemViewModel
{
    public SaveGolfballViewModel() { }

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

    public override string BackNavigationPath => $"Memorabilia/{EditModeType.Update.Name}/{MemorabiliaId}";

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
    public int BrandId { get; set; } = Brand.Titleist.Id;

    public bool DisplayGameDate => GameStyleType.IsGameWorthly(GameStyleType);

    public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

    public override string ExitNavigationPath => "Memorabilia/Items";

    public DateTime? GameDate { get; set; }

    public GameStyleType GameStyleType => GameStyleType.Find(GameStyleTypeId);

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Tournament Style Type is required.")]
    public int GameStyleTypeId { get; set; } = GameStyleType.None.Id;

    public GameStyleType[] GameStyleTypes => GameStyleType.GetAll(ItemType.Golfball);

    public override string ImagePath => Domain.Constants.ImagePath.Golfball;

    public override ItemType ItemType => ItemType.Golfball;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Level is required.")]
    public int LevelTypeId { get; set; } = LevelType.Professional.Id;

    public SavePersonViewModel Person { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
    public int SizeId { get; set; } = Size.Standard.Id;

    public Sport Sport => Sport.Golf;
}
