using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.LevelTypes;

public record GetLevelType(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetLevelType, DomainViewModel>
    {
        private readonly IDomainRepository<LevelType> _levelTypeRepository;

        public Handler(IDomainRepository<LevelType> levelTypeRepository)
        {
            _levelTypeRepository = levelTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetLevelType query)
        {
            return new DomainViewModel(await _levelTypeRepository.Get(query.Id));
        }
    }
}
