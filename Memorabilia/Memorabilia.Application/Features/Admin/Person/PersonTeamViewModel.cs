namespace Memorabilia.Application.Features.Admin.Person
{
    public class PersonTeamViewModel
    {
        private readonly Domain.Entities.PersonTeam _personTeam;

        public PersonTeamViewModel() { }

        public PersonTeamViewModel(Domain.Entities.PersonTeam personTeam)
        {
            _personTeam = personTeam;
        }

        public int? BeginYear => _personTeam.BeginYear;

        public int? EndYear => _personTeam.EndYear; 

        public int Id => _personTeam.Id;

        public int PersonId => _personTeam.PersonId;

        public int TeamId => _personTeam.TeamId;
    }
}
