namespace Memorabilia.Application.Features.Admin.Colors;

public record GetColors() : IQuery<Entity.Color[]>
{
    public class Handler(IDomainRepository<Entity.Color> colorRepository) 
        : QueryHandler<GetColors, Entity.Color[]>
    {
        protected override async Task<Entity.Color[]> Handle(GetColors query)
            => await colorRepository.GetAll();
    }
}
