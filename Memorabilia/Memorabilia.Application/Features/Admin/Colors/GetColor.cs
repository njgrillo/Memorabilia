namespace Memorabilia.Application.Features.Admin.Colors;

public record GetColor(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.Color> colorRepository) 
        : QueryHandler<GetColor, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetColor query)
            => await colorRepository.Get(query.Id);
    }
}
