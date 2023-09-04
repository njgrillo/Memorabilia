namespace Memorabilia.Application.Features.Admin.Franchises;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetFranchises() : IQuery<Entity.Franchise[]>
{
    public class Handler : QueryHandler<GetFranchises, Entity.Franchise[]>
    {
        private readonly IDomainRepository<Entity.Franchise> _franchiseRepository;

        public Handler(IDomainRepository<Entity.Franchise> franchiseRepository)
        {
            _franchiseRepository = franchiseRepository;
        }

        protected override async Task<Entity.Franchise[]> Handle(GetFranchises query)
            => await _franchiseRepository.GetAll();
    }
}
