using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.SportLeagueLevels;

public class SaveSportLeagueLevelViewModel : EditModel
{
    public SaveSportLeagueLevelViewModel() { }

    public SaveSportLeagueLevelViewModel(SportLeagueLevelViewModel viewModel)
    {
        Abbreviation = viewModel.Abbreviation;
        Id = viewModel.Id;
        LevelTypeId = viewModel.LevelTypeId;
        Name = viewModel.Name;            
        SportId = viewModel.SportId;
    }

    [StringLength(10, ErrorMessage = "Abbreviation is too long.")]
    public string Abbreviation { get; set; }

    public override string ExitNavigationPath => AdminDomainItem.SportLeagueLevels.Page;

    public string ImageFileName => AdminDomainItem.SportLeagueLevels.ImageFileName;

    public override string ItemTitle => AdminDomainItem.SportLeagueLevels.Item;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Level Type is required.")]
    public int LevelTypeId { get; set; }

    public LevelType[] LevelTypes => LevelType.All;

    [Required]
    [StringLength(100, ErrorMessage = "Name is too long.")]
    [MinLength(1, ErrorMessage = "Name is too short.")]
    public override string Name { get; set; }

    public override string RoutePrefix => AdminDomainItem.SportLeagueLevels.Page;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Sport is required.")]
    public int SportId { get; set; }

    public Sport[] Sports => Sport.All;
}
