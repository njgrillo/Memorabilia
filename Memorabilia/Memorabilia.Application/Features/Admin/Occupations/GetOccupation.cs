using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Occupations;

public record GetOccupation(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetOccupation, DomainViewModel>
    {
        private readonly IDomainRepository<Occupation> _occupationRepository;

        public Handler(IDomainRepository<Occupation> occupationRepository)
        {
            _occupationRepository = occupationRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetOccupation query)
        {
            return new DomainViewModel(await _occupationRepository.Get(query.Id));
        }
    }
}
