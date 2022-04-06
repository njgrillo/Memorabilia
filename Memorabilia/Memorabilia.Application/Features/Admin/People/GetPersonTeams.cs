using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.People
{
    public class GetPersonTeams
    {
        public class Handler : QueryHandler<Query, IEnumerable<PersonTeamViewModel>>
        {
            private readonly IPersonTeamRepository _personTeamRepository;

            public Handler(IPersonTeamRepository personTeamRepository)
            {
                _personTeamRepository = personTeamRepository;
            }

            protected override async Task<IEnumerable<PersonTeamViewModel>> Handle(Query query)
            {
                var personTeams = await _personTeamRepository.GetAll(query.PersonId).ConfigureAwait(false);

                return personTeams.Select(personTeam => new PersonTeamViewModel(personTeam));
            }
        }

        public class Query : IQuery<IEnumerable<PersonTeamViewModel>>
        {
            public Query(int personId)
            {
                PersonId = personId;
            }

            public int PersonId { get; }
        }
    }
}
