using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Jersey;

public class SaveJerseyViewModel : SaveItemViewModel
{
    public SaveJerseyViewModel() { }

    public SaveJerseyViewModel(JerseyViewModel viewModel)
    {            
        BrandId = viewModel.Brand.BrandId;
        GameDate = viewModel.Game?.GameDate;
        GameStyleTypeId = viewModel.Game?.GameStyleTypeId ?? 0;
        JerseyQualityTypeId = viewModel.Jersey.JerseyQualityTypeId;
        JerseyStyleTypeId = viewModel.Jersey.JerseyStyleTypeId;
        JerseyTypeId = viewModel.Jersey.JerseyTypeId;
        LevelTypeId = viewModel.Level.LevelTypeId;
        MemorabiliaId = viewModel.MemorabiliaId;
        People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
        SizeId = viewModel.Size.SizeId;
        SportId = viewModel.Sports.Select(x => x.SportId).FirstOrDefault();
        Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();
    }

    public override string BackNavigationPath => $"Memorabilia/{EditModeType.Update.Name}/{MemorabiliaId}";

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
    public int BrandId { get; set; }

    public bool DisplayGameDate => DisplayGameStyle && GameStyleType.IsGameWorthly(GameStyleType);

    public bool DisplayGameStyle => JerseyQualityTypeId == JerseyQualityType.Authentic.Id;

    public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

    public override string ExitNavigationPath => "Memorabilia/Items";

    public DateTime? GameDate { get; set; }

    public GameStyleType GameStyleType => GameStyleType.Find(GameStyleTypeId);

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Game Style Type is required.")]
    public int GameStyleTypeId { get; set; } = GameStyleType.None.Id;

    public override string ImageFileName => Domain.Constants.ImageFileName.ItemTypes;

    public bool IsGameWorthly => GameStyleType.IsGameWorthly(GameStyleType);

    public override ItemType ItemType => ItemType.Jersey;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Quality is required.")]
    public int JerseyQualityTypeId { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Style is required.")]
    public int JerseyStyleTypeId { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Type is required.")]
    public int JerseyTypeId { get; set; } = JerseyType.Stitched.Id;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Level is required.")]
    public int LevelTypeId { get; set; } = LevelType.Professional.Id;

    public List<SavePersonViewModel> People { get; set; } = new();

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
    public int SizeId { get; set; }

    public int SportId { get; set; } 

    public List<SaveTeamViewModel> Teams { get; set; } = new();
}
