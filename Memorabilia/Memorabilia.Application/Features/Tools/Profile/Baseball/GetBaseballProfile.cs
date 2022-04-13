using Demo.Framework.Handler;
using Memorabilia.Application.Features.Tools.Profile.Baseball;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Tools.Profile
{
    public class GetBaseballProfile
    {
        public class Handler : QueryHandler<Query, BaseballProfileViewModel>
        {
            private readonly IPersonRepository _personRepository;

            public Handler(IPersonRepository personRepository)
            {
                _personRepository = personRepository;
            }

            protected override async Task<BaseballProfileViewModel> Handle(Query query)
            {
                return new BaseballProfileViewModel(await _personRepository.Get(query.PersonId).ConfigureAwait(false));
            }
        }

        public class Query : IQuery<BaseballProfileViewModel>
        {
            public Query(int personId) 
            { 
                PersonId = personId;
            }

            public int PersonId { get; }
        }
    }
}
