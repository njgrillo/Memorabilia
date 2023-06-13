namespace Memorabilia.Application.Features.Memorabilia;

public record GetMemorabiliaItemsPaged(PageInfo PageInfo, 
                                       MemorabiliaSearchCriteria MemorabiliaSearchCriteria = null) 
    : IQuery<MemorabiliasModel>
{
    public class Handler : QueryHandler<GetMemorabiliaItemsPaged, MemorabiliasModel>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository, 
                       IApplicationStateService applicationStateService)
        {
            _memorabiliaRepository = memorabiliaRepository;
            _applicationStateService = applicationStateService;
        }

        protected override async Task<MemorabiliasModel> Handle(GetMemorabiliaItemsPaged query)
        {
            PagedResult<Entity.Memorabilia> result 
                = await _memorabiliaRepository.GetAll(_applicationStateService.CurrentUser.Id, 
                                                      query.PageInfo, 
                                                      query.MemorabiliaSearchCriteria);

            return new MemorabiliasModel(result.Data, result.PageInfo);
        }
    }
}
