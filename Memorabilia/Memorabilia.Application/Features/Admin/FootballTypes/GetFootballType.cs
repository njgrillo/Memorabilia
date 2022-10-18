using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.FootballTypes;

public record GetFootballType(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetFootballType, DomainViewModel>
    {
        private readonly IDomainRepository<FootballType> _footballTypeRepository;

        public Handler(IDomainRepository<FootballType> footballTypeRepository)
        {
            _footballTypeRepository = footballTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetFootballType query)
        {
            return new DomainViewModel(await _footballTypeRepository.Get(query.Id));
        }
    }
}
