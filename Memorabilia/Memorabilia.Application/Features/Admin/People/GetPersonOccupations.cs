using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.People
{
    public class GetPersonOccupations
    {
        public class Handler : QueryHandler<Query, PersonOccupationViewModel>
        {
            private readonly IPersonRepository _personRepository;

            public Handler(IPersonRepository personRepository)
            {
                _personRepository = personRepository;
            }

            protected override async Task<PersonOccupationViewModel> Handle(Query query)
            {
                return new PersonOccupationViewModel(await _personRepository.Get(query.PersonId).ConfigureAwait(false));
            }
        }

        public class Query : IQuery<PersonOccupationViewModel>
        {
            public Query(int personId)
            {
                PersonId = personId;
            }

            public int PersonId { get; }
        }
    }
}
