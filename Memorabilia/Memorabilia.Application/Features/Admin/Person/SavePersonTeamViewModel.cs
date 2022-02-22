namespace Memorabilia.Application.Features.Admin.Person
{
    public class SavePersonTeamViewModel : SaveViewModel
    {
        public SavePersonTeamViewModel() { }

        public SavePersonTeamViewModel(PersonTeamViewModel team)
        {
            Id = team.Id;
            PersonId = team.PersonId;
            TeamId = team.TeamId;
            BeginYear = team.BeginYear;
            EndYear = team.EndYear;
        }

        public int? BeginYear { get; set; }

        public int? EndYear { get; set; }

        public int PersonId { get; set; }

        public int TeamId { get; set; }
    }
}
