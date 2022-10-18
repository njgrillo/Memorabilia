using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Sports;

public record GetSport(int Id) : IQuery<SportViewModel>
{
    public class Handler : QueryHandler<GetSport, SportViewModel>
    {
        private readonly IDomainRepository<Sport> _sportRepository;

        public Handler(IDomainRepository<Sport> sportRepository)
        {
            _sportRepository = sportRepository;
        }

        protected override async Task<SportViewModel> Handle(GetSport query)
        {
            return new SportViewModel(await _sportRepository.Get(query.Id));
        }
    }
}
