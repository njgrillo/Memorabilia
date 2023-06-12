namespace Memorabilia.Application.Features.Admin.BatTypes;

public record GetBatType(int Id) : IQuery<Entity.BatType>
{
    public class Handler : QueryHandler<GetBatType, Entity.BatType>
    {
        private readonly IDomainRepository<Entity.BatType> _batTypeRepository;

        public Handler(IDomainRepository<Entity.BatType> batTypeRepository)
        {
            _batTypeRepository = batTypeRepository;
        }

        protected override async Task<Entity.BatType> Handle(GetBatType query)
            => await _batTypeRepository.Get(query.Id);
    }
}
