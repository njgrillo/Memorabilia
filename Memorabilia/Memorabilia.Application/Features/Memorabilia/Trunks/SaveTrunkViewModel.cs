using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Trunks;

public class SaveTrunkViewModel : SaveItemViewModel
{
    public SaveTrunkViewModel() { }

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

    public override string BackNavigationPath => $"Memorabilia/{EditModeType.Update.Name}/{MemorabiliaId}";

    public Brand Brand => Brand.Find(BrandId);

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
    public int BrandId { get; set; } = Brand.Rawlings.Id;

    public bool DisplayGameDate => GameStyleType.IsGameWorthly(GameStyleType);

    public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

    public override string ExitNavigationPath => "Memorabilia/Items";

    public DateTime? GameDate { get; set; }

    public GameStyleType GameStyleType => GameStyleType.Find(GameStyleTypeId);

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Match Style Type is required.")]
    public int GameStyleTypeId { get; set; } = GameStyleType.None.Id;

    public override string ImagePath => Domain.Constants.ImagePath.Trunks;

    public override ItemType ItemType => ItemType.Trunks;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Level is required.")]
    public int LevelTypeId { get; set; } = LevelType.Professional.Id;

    public SavePersonViewModel Person { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
    public int SizeId { get; set; } = Size.Standard.Id;

    public int SportId { get; set; }
}
