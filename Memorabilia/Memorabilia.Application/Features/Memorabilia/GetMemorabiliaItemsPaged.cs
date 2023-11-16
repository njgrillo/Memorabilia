using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Application.Features.Memorabilia;

public record GetMemorabiliaItemsPaged(PageInfo PageInfo, 
                                       MemorabiliaSearchCriteria MemorabiliaSearchCriteria = null) 
    : IQuery<MemorabiliasModel>
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository,
                         IApplicationStateService applicationStateService) 
        : QueryHandler<GetMemorabiliaItemsPaged, MemorabiliasModel>
    {
        protected override async Task<MemorabiliasModel> Handle(GetMemorabiliaItemsPaged query)
        {
            PagedResult<Entity.Memorabilia> result 
                = await memorabiliaRepository.GetAll(applicationStateService.CurrentUser.Id, 
                                                      query.PageInfo, 
                                                      query.MemorabiliaSearchCriteria);

            return new MemorabiliasModel(result.Data, result.PageInfo);
        }
    }
}
