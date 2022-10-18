using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Occupations;

public record GetOccupations() : IQuery<OccupationsViewModel>
{
    public class Handler : QueryHandler<GetOccupations, OccupationsViewModel>
    {
        private readonly IDomainRepository<Occupation> _occupationRepository;

        public Handler(IDomainRepository<Occupation> occupationRepository)
        {
            _occupationRepository = occupationRepository;
        }

        protected override async Task<OccupationsViewModel> Handle(GetOccupations query)
        {
            return new OccupationsViewModel(await _occupationRepository.GetAll());
        }
    }
}
