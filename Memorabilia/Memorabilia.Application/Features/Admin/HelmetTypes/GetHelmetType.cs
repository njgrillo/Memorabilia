namespace Memorabilia.Application.Features.Admin.HelmetTypes;

public record GetHelmetType(int Id) : IQuery<Entity.HelmetType>
{
    public class Handler : QueryHandler<GetHelmetType, Entity.HelmetType>
    {
        private readonly IDomainRepository<Entity.HelmetType> _helmetTypeRepository;

        public Handler(IDomainRepository<Entity.HelmetType> helmetTypeRepository)
        {
            _helmetTypeRepository = helmetTypeRepository;
        }

        protected override async Task<Entity.HelmetType> Handle(GetHelmetType query)
            => await _helmetTypeRepository.Get(query.Id);
    }
}
