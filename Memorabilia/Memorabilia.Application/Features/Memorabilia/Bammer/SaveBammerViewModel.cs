using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Bammer;

public class SaveBammerViewModel : SaveItemViewModel
{
    public SaveBammerViewModel() { }

    public SaveBammerViewModel(BammerViewModel viewModel)
    {
        BammerTypeId = viewModel.Bammer?.BammerTypeId ?? 0;
        BrandId = viewModel.Brand.BrandId;
        InPackage = viewModel.Bammer?.InPackage ?? false;
        LevelTypeId = viewModel.Level.LevelTypeId;
        MemorabiliaId = viewModel.MemorabiliaId;
        People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
        SportId = viewModel.Sports.Select(x => x.SportId).FirstOrDefault();
        Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();
        Year = viewModel.Bammer?.Year;
    }

    public override string BackNavigationPath => $"Memorabilia/{EditModeType.Update.Name}/{MemorabiliaId}";

    public int BammerTypeId { get; set; }

    public BammerType[] BammerTypes => BammerType.All;

    public Brand Brand => Brand.Find(BrandId);

    public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
    public int BrandId { get; set; }

    public override string ExitNavigationPath => "Memorabilia/Items";

    public override string ImagePath => Domain.Constants.ImagePath.Bammer;

    public bool InPackage { get; set; }

    public override ItemType ItemType => ItemType.Bammer;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Level is required.")]
    public int LevelTypeId { get; set; }

    public override string PageTitle => $"{(EditModeType == EditModeType.Update ? EditModeType.Update.Name : EditModeType.Add.Name)} {ItemType.Bammer.Name} Details";

    public List<SavePersonViewModel> People { get; set; } = new();

    public int SportId { get; set; }

    public List<SaveTeamViewModel> Teams { get; set; } = new();

    public int? Year { get; set; }
}
