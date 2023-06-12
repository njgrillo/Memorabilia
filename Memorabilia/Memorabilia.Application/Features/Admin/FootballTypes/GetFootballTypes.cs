namespace Memorabilia.Application.Features.Admin.FootballTypes;

public record GetFootballTypes() : IQuery<Entity.FootballType[]>
{
    public class Handler : QueryHandler<GetFootballTypes, Entity.FootballType[]>
    {
        private readonly IDomainRepository<Entity.FootballType> _footballTypeRepository;

        public Handler(IDomainRepository<Entity.FootballType> footballTypeRepository)
        {
            _footballTypeRepository = footballTypeRepository;
        }

        protected override async Task<Entity.FootballType[]> Handle(GetFootballTypes query)
            => (await _footballTypeRepository.GetAll())
                    .ToArray();
    }
}
