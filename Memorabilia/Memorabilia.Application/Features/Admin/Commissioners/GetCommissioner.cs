namespace Memorabilia.Application.Features.Admin.Commissioners;

public record GetCommissioner(int Id) : IQuery<Entity.Commissioner>
{
    public class Handler(ICommissionerRepository commissionerRepository) 
        : QueryHandler<GetCommissioner, Entity.Commissioner>
    {
        protected override async Task<Entity.Commissioner> Handle(GetCommissioner query)
            => await commissionerRepository.Get(query.Id);
    }
}
