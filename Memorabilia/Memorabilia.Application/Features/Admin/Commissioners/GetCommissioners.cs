namespace Memorabilia.Application.Features.Admin.Commissioners;

public record GetCommissioners(int? SportLeagueLevelId = null) 
    : IQuery<Entity.Commissioner[]>
{
    public class Handler : QueryHandler<GetCommissioners, Entity.Commissioner[]>
    {
        private readonly ICommissionerRepository _commissionerRepository;

        public Handler(ICommissionerRepository commissionerRepository)
        {
            _commissionerRepository = commissionerRepository;
        }

        protected override async Task<Entity.Commissioner[]> Handle(GetCommissioners query)
            => await _commissionerRepository.GetAll(query.SportLeagueLevelId);
    }
}
