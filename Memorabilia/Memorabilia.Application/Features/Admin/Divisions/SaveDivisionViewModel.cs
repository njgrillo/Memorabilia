namespace Memorabilia.Application.Features.Admin.Divisions
{
    public class SaveDivisionViewModel : SaveViewModel
    {
        public SaveDivisionViewModel() { }

        public SaveDivisionViewModel(DivisionViewModel viewModel)
        {
            Abbreviation = viewModel.Abbreviation;
            ConferenceId = viewModel.ConferenceId ?? 0;
            Id = viewModel.Id;
            LeagueId = viewModel.LeagueId ?? 0;
            Name = viewModel.Name;
        }

        [StringLength(10, ErrorMessage = "Abbreviation is too long.")]
        public string Abbreviation { get; set; }

        public int ConferenceId { get; set; }

        public Domain.Constants.Conference[] Conferences => Domain.Constants.Conference.All;

        public override string ExitNavigationPath => "Divisions";

        public string ImagePath => "images/divisions.png";

        public override string ItemTitle => "Division";

        public int LeagueId { get; set; }

        public Domain.Constants.League[] Leagues => Domain.Constants.League.All;

        [Required]
        [StringLength(100, ErrorMessage = "Name is too long.")]
        [MinLength(1, ErrorMessage = "Name is too short.")]
        public string Name { get; set; }

        public override string PageTitle => $"{(Id > 0 ? "Edit" : "Add")} Division";

        public override string RoutePrefix => "Divisions";              
    }
}
