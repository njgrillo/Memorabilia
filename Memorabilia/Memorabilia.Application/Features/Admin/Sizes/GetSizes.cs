namespace Memorabilia.Application.Features.Admin.Sizes;

public record GetSizes() : IQuery<Entity.Size[]>
{
    public class Handler(IDomainRepository<Entity.Size> sizeRepository) 
        : QueryHandler<GetSizes, Entity.Size[]>
    {
        protected override async Task<Entity.Size[]> Handle(GetSizes query)
            => await sizeRepository.GetAll();
    }
}
