using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Helmet;

public class SaveHelmetViewModel : SaveItemViewModel
{
    public SaveHelmetViewModel() { }

    public SaveHelmetViewModel(HelmetViewModel viewModel)
    {
        BrandId = viewModel.Brand.BrandId;
        GameDate = viewModel.Game?.GameDate;
        GameStyleTypeId = viewModel.Game?.GameStyleTypeId ?? 0;
        HelmetFinishId = viewModel.Helmet.HelmetFinishId ?? 0;
        HelmetQualityTypeId = viewModel.Helmet.HelmetQualityTypeId ?? 0;
        HelmetTypeId = viewModel.Helmet.HelmetTypeId ?? 0;
        LevelTypeId = viewModel.Level.LevelTypeId;
        MemorabiliaId = viewModel.MemorabiliaId;
        People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
        SizeId = viewModel.Size.SizeId;
        SportIds = viewModel.Sports.Select(x => x.SportId).ToList();
        Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();
        Throwback = viewModel.Helmet.Throwback;
    }

    public override string BackNavigationPath => $"Memorabilia/{EditModeType.Update.Name}/{MemorabiliaId}";

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
    public int BrandId { get; set; } = Brand.Riddell.Id;

    public bool CanEditHelmetQualityType { get; private set; } = true;

    public bool DisplayGameDate => IsGameWorthly && DisplayGameStyle;

    public bool DisplayGameStyle => SizeId == Size.Full.Id;

    public bool DisplayHelmetFinish => !IsGameWorthly;

    public bool DisplayHelmetQualityType => Size.Find(SizeId) == Size.Full;

    public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

    public override string ExitNavigationPath => "Memorabilia/Items";

    public DateTime? GameDate { get; set; }

    public GameStyleType GameStyleType => GameStyleType.Find(GameStyleTypeId);

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Game Style Type is required.")]
    public int GameStyleTypeId { get; set; } = GameStyleType.None.Id;

    public int HelmetFinishId { get; set; }

    public int HelmetQualityTypeId { get; set; }

    public int HelmetTypeId { get; set; }

    public HelmetType[] HelmetTypes { get; set; } = HelmetType.All;

    public override string ImageFileName => Domain.Constants.ImageFileName.Helmet;

    public bool IsGameWorthly => GameStyleType.IsGameWorthly(GameStyleType);

    public override ItemType ItemType => ItemType.Helmet;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Level is required.")]
    public int LevelTypeId { get; set; } = LevelType.Professional.Id;

    public List<SavePersonViewModel> People { get; set; } = new();

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
    public int SizeId { get; set; } = Size.Mini.Id;

    public List<int> SportIds { get; set; } = new();

    public List<SaveTeamViewModel> Teams { get; set; } = new();

    public bool Throwback { get; set; }
}
