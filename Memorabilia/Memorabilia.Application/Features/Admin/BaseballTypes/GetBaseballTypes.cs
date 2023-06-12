namespace Memorabilia.Application.Features.Admin.BaseballTypes;

public record GetBaseballTypes() : IQuery<Entity.BaseballType[]>
{
    public class Handler : QueryHandler<GetBaseballTypes, Entity.BaseballType[]>
    {
        private readonly IDomainRepository<Entity.BaseballType> _baseballTypeRepository;

        public Handler(IDomainRepository<Entity.BaseballType> baseballTypeRepository)
        {
            _baseballTypeRepository = baseballTypeRepository;
        }

        protected override async Task<Entity.BaseballType[]> Handle(GetBaseballTypes query)
            => (await _baseballTypeRepository.GetAll()).ToArray();
    }
}
