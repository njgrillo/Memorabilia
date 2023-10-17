namespace Memorabilia.Application.Features.SiteMemorabilia;

public record GetUserSiteMemorabiliaItems(int UserId,
                                          PageInfo PageInfo,
                                          MemorabiliaSearchCriteria MemorabiliaSearchCriteria = null)
    : IQuery<SiteMemorabiliasModel>
{
    public class Handler : QueryHandler<GetUserSiteMemorabiliaItems, SiteMemorabiliasModel>
    {
        private readonly ISiteMemorabiliaRepository _memorabiliaRepository;

        public Handler(ISiteMemorabiliaRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<SiteMemorabiliasModel> Handle(GetUserSiteMemorabiliaItems query)
        {
            PagedResult<Entity.Memorabilia> result
                = await _memorabiliaRepository.GetAllByUser(query.UserId, 
                                                            query.PageInfo,
                                                            query.MemorabiliaSearchCriteria);

            return new SiteMemorabiliasModel(result.Data, result.PageInfo);
        }
    }
}
