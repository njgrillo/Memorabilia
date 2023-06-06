using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Occupations;

public record GetOccupation(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetOccupation, DomainModel>
    {
        private readonly IDomainRepository<Occupation> _occupationRepository;

        public Handler(IDomainRepository<Occupation> occupationRepository)
        {
            _occupationRepository = occupationRepository;
        }

        protected override async Task<DomainModel> Handle(GetOccupation query)
        {
            return new DomainModel(await _occupationRepository.Get(query.Id));
        }
    }
}
