namespace Memorabilia.Application.Features.Admin.Commissioners;

public record GetCommissioners(int? SportLeagueLevelId = null) 
    : IQuery<Entity.Commissioner[]>
{
    public class Handler(ICommissionerRepository commissionerRepository) 
        : QueryHandler<GetCommissioners, Entity.Commissioner[]>
    {
        protected override async Task<Entity.Commissioner[]> Handle(GetCommissioners query)
            => await commissionerRepository.GetAll(query.SportLeagueLevelId);
    }
}
