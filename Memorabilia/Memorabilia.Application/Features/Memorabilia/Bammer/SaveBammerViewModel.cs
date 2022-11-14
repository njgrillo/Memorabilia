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

    public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
    public int BrandId { get; set; } = Brand.Salvino.Id;

    public override string ExitNavigationPath => "Memorabilia/Items";

    public override string ImageFileName => Domain.Constants.ImageFileName.Bammer;

    public bool InPackage { get; set; }

    public override ItemType ItemType => ItemType.Bammer;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Level is required.")]
    public int LevelTypeId { get; set; } = LevelType.Professional.Id;
  
    public List<SavePersonViewModel> People { get; set; } = new();

    public int SportId { get; set; }

    public List<SaveTeamViewModel> Teams { get; set; } = new();

    public int? Year { get; set; }
}
