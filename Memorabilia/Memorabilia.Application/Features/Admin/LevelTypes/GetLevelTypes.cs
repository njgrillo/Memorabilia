using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.LevelTypes;

public record GetLevelTypes() : IQuery<LevelTypesViewModel>
{
    public class Handler : QueryHandler<GetLevelTypes, LevelTypesViewModel>
    {
        private readonly IDomainRepository<LevelType> _levelTypeRepository;

        public Handler(IDomainRepository<LevelType> levelTypeRepository)
        {
            _levelTypeRepository = levelTypeRepository;
        }

        protected override async Task<LevelTypesViewModel> Handle(GetLevelTypes query)
        {
            return new LevelTypesViewModel(await _levelTypeRepository.GetAll());
        }
    }
}
