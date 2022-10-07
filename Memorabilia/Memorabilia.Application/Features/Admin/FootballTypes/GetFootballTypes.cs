using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.FootballTypes;

public class GetFootballTypes
{
    public class Handler : QueryHandler<Query, FootballTypesViewModel>
    {
        private readonly IDomainRepository<FootballType> _footballTypeRepository;

        public Handler(IDomainRepository<FootballType> footballTypeRepository)
        {
            _footballTypeRepository = footballTypeRepository;
        }

        protected override async Task<FootballTypesViewModel> Handle(Query query)
        {
            return new FootballTypesViewModel(await _footballTypeRepository.GetAll());
        }
    }

    public class Query : IQuery<FootballTypesViewModel> { }
}
