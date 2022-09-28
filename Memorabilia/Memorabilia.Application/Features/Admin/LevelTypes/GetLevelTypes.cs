namespace Memorabilia.Application.Features.Admin.LevelTypes
{
    public class GetLevelTypes
    {
        public class Handler : QueryHandler<Query, LevelTypesViewModel>
        {
            private readonly ILevelTypeRepository _levelTypeRepository;

            public Handler(ILevelTypeRepository levelTypeRepository)
            {
                _levelTypeRepository = levelTypeRepository;
            }

            protected override async Task<LevelTypesViewModel> Handle(Query query)
            {
                return new LevelTypesViewModel(await _levelTypeRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<LevelTypesViewModel> { }
    }
}
