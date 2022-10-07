using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Pewters;

public class GetPewters
{
    public class Handler : QueryHandler<Query, PewtersViewModel>
    {
        private readonly IDomainRepository<Pewter> _pewterRepository;

        public Handler(IDomainRepository<Pewter> pewterRepository)
        {
            _pewterRepository = pewterRepository;
        }

        protected override async Task<PewtersViewModel> Handle(Query query)
        {
            return new PewtersViewModel(await _pewterRepository.GetAll());
        }
    }

    public class Query : IQuery<PewtersViewModel> { }
}
