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
            var pewters = (await _pewterRepository.GetAll())
                                .OrderBy(pewter => pewter.FranchiseName)
                                .ThenBy(pewter => pewter.Team.Name)
                                .ThenBy(pewter => pewter.SizeName)
                                .ThenBy(pewter => pewter.ImageTypeName);

            return new PewtersViewModel(pewters);
        }
    }

    public class Query : IQuery<PewtersViewModel> { }
}
