using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.GameStyleTypes;

public record GetGameStyleType(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetGameStyleType, DomainModel>
    {
        private readonly IDomainRepository<GameStyleType> _gameStyleTypeRepository;

        public Handler(IDomainRepository<GameStyleType> gameStyleTypeRepository)
        {
            _gameStyleTypeRepository = gameStyleTypeRepository;
        }

        protected override async Task<DomainModel> Handle(GetGameStyleType query)
        {
            return new DomainModel(await _gameStyleTypeRepository.Get(query.Id));
        }
    }
}
