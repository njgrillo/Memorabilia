using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Person
{
    public class GetPersonOccupations
    {
        public class Handler : QueryHandler<Query, IEnumerable<PersonOccupationViewModel>>
        {
            private readonly IPersonOccupationRepository _personOccupationRepository;

            public Handler(IPersonOccupationRepository personOccupationRepository)
            {
                _personOccupationRepository = personOccupationRepository;
            }

            protected override async Task<IEnumerable<PersonOccupationViewModel>> Handle(Query query)
            {
                var personOccupations = await _personOccupationRepository.GetAll(query.PersonId).ConfigureAwait(false);

                return personOccupations.Select(personOccupation => new PersonOccupationViewModel(personOccupation));
            }
        }

        public class Query : IQuery<IEnumerable<PersonOccupationViewModel>>
        {
            public Query(int personId)
            {
                PersonId = personId;
            }

            public int PersonId { get; }
        }
    }
}
