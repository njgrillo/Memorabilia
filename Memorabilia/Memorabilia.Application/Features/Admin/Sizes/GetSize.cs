namespace Memorabilia.Application.Features.Admin.Sizes;

public record GetSize(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetSize, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.Size> _sizeRepository;

        public Handler(IDomainRepository<Entity.Size> sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetSize query)
            => await _sizeRepository.Get(query.Id);
    }
}
