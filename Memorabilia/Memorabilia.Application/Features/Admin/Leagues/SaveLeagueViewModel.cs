namespace Memorabilia.Application.Features.Admin.Leagues
{
    public class SaveLeagueViewModel : SaveViewModel
    {
        public SaveLeagueViewModel() { }

        public SaveLeagueViewModel(LeagueViewModel viewModel)
        {
            Abbreviation = viewModel.Abbreviation;
            Id = viewModel.Id;
            Name = viewModel.Name;
            SportLeagueLevelId = viewModel.SportLeagueLevelId;
        }

        [StringLength(10, ErrorMessage = "Abbreviation is too long.")]
        public string Abbreviation { get; set; }

        public override string ExitNavigationPath => "Leagues";

        public string ImagePath => "images/sports.jpg";

        public override string ItemTitle => "League";

        [Required]
        [StringLength(100, ErrorMessage = "Name is too long.")]
        [MinLength(1, ErrorMessage = "Name is too short.")]
        public string Name { get; set; }

        public override string PageTitle => $"{(EditModeType == Domain.Constants.EditModeType.Update ? "Edit" : "Add")} League";

        public override string RoutePrefix => "Leagues";

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Sport League Level is required.")]
        public int SportLeagueLevelId { get; set; }
    }
}
