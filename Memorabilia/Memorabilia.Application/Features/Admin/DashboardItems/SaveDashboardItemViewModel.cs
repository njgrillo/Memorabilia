using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.DashboardItems;

public class SaveDashboardItemViewModel : SaveViewModel
{
    public SaveDashboardItemViewModel() { }

    public SaveDashboardItemViewModel(DashboardItemViewModel viewModel)
    {
        Description = viewModel.Description;
        Id = viewModel.Id;
        Name = viewModel.Name;
    }

    [Required]
    [StringLength(500, ErrorMessage = "Description is too long.")]
    [MinLength(1, ErrorMessage = "Description is too short.")]
    public string Description { get; set; }

    public override string ExitNavigationPath => AdminDomainItem.DashboardItems.Page;

    public string ImagePath => AdminDomainItem.DashboardItems.ImagePath;

    public override string ItemTitle => AdminDomainItem.DashboardItems.Item;

    [Required]
    [StringLength(100, ErrorMessage = "Name is too long.")]
    [MinLength(1, ErrorMessage = "Name is too short.")]
    public string Name { get; set; }

    public override string RoutePrefix => AdminDomainItem.DashboardItems.Page;
}


