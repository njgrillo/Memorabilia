using System.ComponentModel.DataAnnotations;

namespace Memorabilia.Application.Features.Admin.DashboardItems
{
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

        public override string ExitNavigationPath => "DashboardItems";

        public string ImagePath => "images/dashboard.jpg";

        public override string ItemTitle => "Dashboard Item";

        [Required]
        [StringLength(100, ErrorMessage = "Name is too long.")]
        [MinLength(1, ErrorMessage = "Name is too short.")]
        public string Name { get; set; }

        public override string PageTitle => $"{(Id > 0 ? "Edit" : "Add")} Dashboard Item";

        public override string RoutePrefix => "DashboardItems";
    }
}


