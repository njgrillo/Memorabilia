using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.GameStyleTypes;

public record GetGameStyleType(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetGameStyleType, DomainViewModel>
    {
        private readonly IDomainRepository<GameStyleType> _gameStyleTypeRepository;

        public Handler(IDomainRepository<GameStyleType> gameStyleTypeRepository)
        {
            _gameStyleTypeRepository = gameStyleTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetGameStyleType query)
        {
            return new DomainViewModel(await _gameStyleTypeRepository.Get(query.Id));
        }
    }
}
