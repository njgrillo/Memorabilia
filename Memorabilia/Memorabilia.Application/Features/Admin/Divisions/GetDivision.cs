namespace Memorabilia.Application.Features.Admin.Divisions;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetDivision(int Id) : IQuery<Entity.Division>
{
    public class Handler : QueryHandler<GetDivision, Entity.Division>
    {
        private readonly IDomainRepository<Entity.Division> _divisionRepository;

        public Handler(IDomainRepository<Entity.Division> divisionRepository)
        {
            _divisionRepository = divisionRepository;
        }

        protected override async Task<Entity.Division> Handle(GetDivision query)
            => await _divisionRepository.Get(query.Id);
    }
}
