namespace Memorabilia.Application.Features.Admin.Franchises
{
    public class SaveFranchiseViewModel : SaveViewModel
    {
        public SaveFranchiseViewModel() { }

        public SaveFranchiseViewModel(FranchiseViewModel viewModel)
        {            
            Id = viewModel.Id;
            Location = viewModel.Location;
            Name = viewModel.Name;
            FoundYear = viewModel.FoundYear;
            SportLeagueLevelId = viewModel.SportLeagueLevelId;
        }

        public override string ExitNavigationPath => "Franchises";

        [Required]
        public int FoundYear { get; set; } = 1900;

        public string ImagePath => "images/franchises.jpg";

        public override string ItemTitle => "Franchise";

        [Required]
        [StringLength(100, ErrorMessage = "Location is too long.")]
        [MinLength(1, ErrorMessage = "Location is too short.")]
        public string Location { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name is too long.")]
        [MinLength(1, ErrorMessage = "Name is too short.")]
        public string Name { get; set; }

        public override string PageTitle => $"{(Id > 0 ? "Edit" : "Add")} {ItemTitle}";

        public override string RoutePrefix => "Franchises";

        [Required]
        public int SportLeagueLevelId { get; set; }
    }
}
