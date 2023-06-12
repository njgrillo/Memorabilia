namespace Memorabilia.Application.Features.Admin.Divisions;

public record GetDivisions() : IQuery<Entity.Division[]>
{
    public class Handler : QueryHandler<GetDivisions, Entity.Division[]>
    {
        private readonly IDomainRepository<Entity.Division> _divisionRepository;

        public Handler(IDomainRepository<Entity.Division> divisionRepository)
        {
            _divisionRepository = divisionRepository;
        }

        protected override async Task<Entity.Division[]> Handle(GetDivisions query)
            => await _divisionRepository.GetAll();
    }
}
