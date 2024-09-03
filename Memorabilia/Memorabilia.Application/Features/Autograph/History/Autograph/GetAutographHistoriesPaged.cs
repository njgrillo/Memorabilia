namespace Memorabilia.Application.Features.Autograph.History.Autograph;

public record GetAutographHistoriesPaged(int Id, PageInfo PageInfo)
    : IQuery<AutographHistoriesModel>
{
    public class Handler(IAutographRepository autographRepository)
        : QueryHandler<GetAutographHistoriesPaged, AutographHistoriesModel>
    {
        protected override async Task<AutographHistoriesModel> Handle(GetAutographHistoriesPaged query)
        {
            PagedResult<Entity.Autograph> result
                = await autographRepository.GetAllHistory(
                    query.Id,
                    query.PageInfo);

            return new AutographHistoriesModel(result.Data, result.PageInfo);
        }
    }
}
