using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.FootballTypes;

public record GetFootballTypes() : IQuery<FootballTypesViewModel>
{
    public class Handler : QueryHandler<GetFootballTypes, FootballTypesViewModel>
    {
        private readonly IDomainRepository<FootballType> _footballTypeRepository;

        public Handler(IDomainRepository<FootballType> footballTypeRepository)
        {
            _footballTypeRepository = footballTypeRepository;
        }

        protected override async Task<FootballTypesViewModel> Handle(GetFootballTypes query)
        {
            return new FootballTypesViewModel(await _footballTypeRepository.GetAll());
        }
    }
}
