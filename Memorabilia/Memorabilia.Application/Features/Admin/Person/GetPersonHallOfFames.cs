using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Person
{
    public class GetPersonHallOfFames
    {
        public class Handler : QueryHandler<Query, IEnumerable<PersonHallOfFameViewModel>>
        {
            private readonly IHallOfFameRepository _personHallOfFameRepository;

            public Handler(IHallOfFameRepository personHallOfFameRepository)
            {
                _personHallOfFameRepository = personHallOfFameRepository;
            }

            protected override async Task<IEnumerable<PersonHallOfFameViewModel>> Handle(Query query)
            {
                var personHallOfFames = await _personHallOfFameRepository.GetAll(query.PersonId).ConfigureAwait(false);

                return personHallOfFames.Select(personHallOfFame => new PersonHallOfFameViewModel(personHallOfFame));
            }
        }

        public class Query : IQuery<IEnumerable<PersonHallOfFameViewModel>>
        {
            public Query(int personId)
            {
                PersonId = personId;
            }

            public int PersonId { get; }
        }
    }
}
