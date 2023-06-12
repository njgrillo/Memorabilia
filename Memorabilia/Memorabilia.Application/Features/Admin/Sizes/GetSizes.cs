namespace Memorabilia.Application.Features.Admin.Sizes;

public record GetSizes() : IQuery<Entity.Size[]>
{
    public class Handler : QueryHandler<GetSizes, Entity.Size[]>
    {
        private readonly IDomainRepository<Entity.Size> _sizeRepository;

        public Handler(IDomainRepository<Entity.Size> sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }

        protected override async Task<Entity.Size[]> Handle(GetSizes query)
            => (await _sizeRepository.GetAll())
                    .ToArray();
    }
}
