using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Person
{
    public class GetPerson
    {
        public class Handler : QueryHandler<Query, PersonViewModel>
        {
            private readonly IPersonRepository _personRepository;

            public Handler(IPersonRepository personRepository)
            {
                _personRepository = personRepository;
            }

            protected override async Task<PersonViewModel> Handle(Query query)
            {
                var person = await _personRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new PersonViewModel(person);

                return viewModel;
            }
        }

        public class Query : IQuery<PersonViewModel>
        {
            public Query(int id)
            {
                Id = id;
            }

            public int Id { get; }
        }
    }
}
