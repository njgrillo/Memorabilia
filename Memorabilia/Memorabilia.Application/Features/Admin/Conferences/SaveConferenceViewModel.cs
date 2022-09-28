namespace Memorabilia.Application.Features.Admin.Conferences
{
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

        public override string ExitNavigationPath => "Conferences";

        public string ImagePath => "images/conferences.jpg";

        public override string ItemTitle => "Conference";

        [Required]
        [StringLength(100, ErrorMessage = "Name is too long.")]
        [MinLength(1, ErrorMessage = "Name is too short.")]
        public string Name { get; set; }

        public override string PageTitle => $"{(EditModeType == Domain.Constants.EditModeType.Update ? "Edit" : "Add")} Conference";

        public override string RoutePrefix => "Conferences";

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Sport League Level is required.")]
        public int SportLeagueLevelId { get; set; }
    }
}
