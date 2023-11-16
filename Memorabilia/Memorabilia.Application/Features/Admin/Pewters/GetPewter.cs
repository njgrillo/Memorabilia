namespace Memorabilia.Application.Features.Admin.Pewters;

public record GetPewter(int Id) : IQuery<Entity.Pewter>
{
    public class Handler(IDomainRepository<Entity.Pewter> pewterRepository) 
        : QueryHandler<GetPewter, Entity.Pewter>
    {
        protected override async Task<Entity.Pewter> Handle(GetPewter query)
            => await pewterRepository.Get(query.Id);
    }
}
