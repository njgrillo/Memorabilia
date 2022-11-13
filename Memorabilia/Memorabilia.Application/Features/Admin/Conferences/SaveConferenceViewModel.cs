using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.Conferences;

public class SaveConferenceViewModel : SaveViewModel
{
    public SaveConferenceViewModel() { }

    public SaveConferenceViewModel(ConferenceViewModel viewModel)
    {
        Abbreviation = viewModel.Abbreviation;
        Id = viewModel.Id;
        Name = viewModel.Name;
        SportLeagueLevelId = viewModel.SportLeagueLevelId;
    }

    [StringLength(10, ErrorMessage = "Abbreviation is too long.")]
    public string Abbreviation { get; set; }

    public override string ExitNavigationPath => AdminDomainItem.Conferences.Page;

    public string ImageFileName => AdminDomainItem.Conferences.ImageFileName;

    public override string ItemTitle => AdminDomainItem.Conferences.Item;

    [Required]
    [StringLength(100, ErrorMessage = "Name is too long.")]
    [MinLength(1, ErrorMessage = "Name is too short.")]
    public override string Name { get; set; }    

    public override string RoutePrefix => AdminDomainItem.Conferences.Page;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Sport League Level is required.")]
    public int SportLeagueLevelId { get; set; }
}
