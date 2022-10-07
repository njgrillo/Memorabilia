using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.LevelTypes;

public class GetLevelTypes
{
    public class Handler : QueryHandler<Query, LevelTypesViewModel>
    {
        private readonly IDomainRepository<LevelType> _levelTypeRepository;

        public Handler(IDomainRepository<LevelType> levelTypeRepository)
        {
            _levelTypeRepository = levelTypeRepository;
        }

        protected override async Task<LevelTypesViewModel> Handle(Query query)
        {
            return new LevelTypesViewModel(await _levelTypeRepository.GetAll());
        }
    }

    public class Query : IQuery<LevelTypesViewModel> { }
}
