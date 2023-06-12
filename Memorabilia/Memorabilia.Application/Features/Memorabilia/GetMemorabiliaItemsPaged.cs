namespace Memorabilia.Application.Features.Memorabilia;

public record GetMemorabiliaItemsPaged(int UserId, 
                                       PageInfo PageInfo, 
                                       MemorabiliaSearchCriteria MemorabiliaSearchCriteria = null) 
    : IQuery<MemorabiliasModel>
{
    public class Handler : QueryHandler<GetMemorabiliaItemsPaged, MemorabiliasModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<MemorabiliasModel> Handle(GetMemorabiliaItemsPaged query)
        {
            PagedResult<Entity.Memorabilia> result 
                = await _memorabiliaRepository.GetAll(query.UserId, 
                                                      query.PageInfo, 
                                                      query.MemorabiliaSearchCriteria);

            return new MemorabiliasModel(result.Data, result.PageInfo);
        }
    }
}
