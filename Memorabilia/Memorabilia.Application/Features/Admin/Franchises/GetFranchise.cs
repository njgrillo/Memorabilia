namespace Memorabilia.Application.Features.Admin.Franchises;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetFranchise(int Id) : IQuery<Entity.Franchise>
{
    public class Handler : QueryHandler<GetFranchise, Entity.Franchise>
    {
        private readonly IDomainRepository<Entity.Franchise> _franchiseRepository;

        public Handler(IDomainRepository<Entity.Franchise> franchiseRepository)
        {
            _franchiseRepository = franchiseRepository;
        }

        protected override async Task<Entity.Franchise> Handle(GetFranchise query)
            => await _franchiseRepository.Get(query.Id);
    }
}
