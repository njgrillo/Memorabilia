namespace Memorabilia.Application.Features.Admin.Team
{
    public class SaveTeamDivisionViewModel : SaveViewModel
    {
        public SaveTeamDivisionViewModel() { }

        public SaveTeamDivisionViewModel(TeamDivisionViewModel teamDivision)
        {
            Id = teamDivision.Id;
            DivisionId = teamDivision.DivisionId;
            TeamId = teamDivision.TeamId;
            BeginYear = teamDivision.BeginYear;
            EndYear = teamDivision.EndYear;
        }

        public int? BeginYear { get; set; }

        public int DivisionId { get; set; }

        public string DivisionName => Domain.Constants.Division.Find(DivisionId)?.Name;

        public int? EndYear { get; set; }

        public int TeamId { get; set; }
    }
}
