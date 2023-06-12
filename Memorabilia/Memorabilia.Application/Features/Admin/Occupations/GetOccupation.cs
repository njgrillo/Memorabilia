namespace Memorabilia.Application.Features.Admin.Occupations;

public record GetOccupation(int Id) : IQuery<Entity.Occupation>
{
    public class Handler : QueryHandler<GetOccupation, Entity.Occupation>
    {
        private readonly IDomainRepository<Entity.Occupation> _occupationRepository;

        public Handler(IDomainRepository<Entity.Occupation> occupationRepository)
        {
            _occupationRepository = occupationRepository;
        }

        protected override async Task<Entity.Occupation> Handle(GetOccupation query)
            => await _occupationRepository.Get(query.Id);
    }
}
