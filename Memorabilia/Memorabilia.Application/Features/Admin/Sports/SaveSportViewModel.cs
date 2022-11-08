using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.Sports;

public class SaveSportViewModel : SaveViewModel
{
    public SaveSportViewModel() { }

    public SaveSportViewModel(SportViewModel viewModel)
    {
        AlternateName = viewModel.AlternateName;
        Id = viewModel.Id;
        Name = viewModel.Name;
    }

    [StringLength(50, ErrorMessage = "Alternate Name is too long.")]
    public string AlternateName { get; set; }

    public override string ExitNavigationPath => AdminDomainItem.Sports.Page;

    public string ImageFileName => AdminDomainItem.Sports.ImageFileName;

    public override string ItemTitle => AdminDomainItem.Sports.Item;

    [Required]
    [StringLength(50, ErrorMessage = "Name is too long.")]
    [MinLength(1, ErrorMessage = "Name is too short.")]
    public string Name { get; set; }

    public override string RoutePrefix => AdminDomainItem.Sports.Page;
}
