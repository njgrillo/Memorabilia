using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Sports;

public record GetSports() : IQuery<SportsViewModel>
{
    public class Handler : QueryHandler<GetSports, SportsViewModel>
    {
        private readonly IDomainRepository<Sport> _sportRepository;

        public Handler(IDomainRepository<Sport> sportRepository)
        {
            _sportRepository = sportRepository;
        }

        protected override async Task<SportsViewModel> Handle(GetSports query)
        {
            var sports = (await _sportRepository.GetAll()).OrderBy(sport => sport.Name);

            return new SportsViewModel(sports);
        }
    }
}
