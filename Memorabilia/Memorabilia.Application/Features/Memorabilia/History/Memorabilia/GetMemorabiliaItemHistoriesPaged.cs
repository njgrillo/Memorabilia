namespace Memorabilia.Application.Features.Memorabilia.History.Memorabilia;

public record GetMemorabiliaItemHistoriesPaged(int Id, PageInfo PageInfo)
    : IQuery<MemorabiliaItemHistoriesModel>
{
    public class Handler(IMemorabiliaItemRepository memorabiliaItemRepository)
        : QueryHandler<GetMemorabiliaItemHistoriesPaged, MemorabiliaItemHistoriesModel>
    {
        protected override async Task<MemorabiliaItemHistoriesModel> Handle(GetMemorabiliaItemHistoriesPaged query)
        {
            PagedResult<Entity.Memorabilia> result
                = await memorabiliaItemRepository.GetAllHistory(
                    query.Id,
                    query.PageInfo);

            return new MemorabiliaItemHistoriesModel(result.Data, result.PageInfo);
        }
    }
}
