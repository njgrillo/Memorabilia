namespace Memorabilia.Application.Features.Admin.FootballTypes;

public record GetFootballType(int Id) : IQuery<Entity.FootballType>
{
    public class Handler : QueryHandler<GetFootballType, Entity.FootballType>
    {
        private readonly IDomainRepository<Entity.FootballType> _footballTypeRepository;

        public Handler(IDomainRepository<Entity.FootballType> footballTypeRepository)
        {
            _footballTypeRepository = footballTypeRepository;
        }

        protected override async Task<Entity.FootballType> Handle(GetFootballType query)
            => await _footballTypeRepository.Get(query.Id);
    }
}
