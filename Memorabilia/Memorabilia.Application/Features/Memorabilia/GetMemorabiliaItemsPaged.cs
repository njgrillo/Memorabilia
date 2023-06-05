namespace Memorabilia.Application.Features.Memorabilia;

public record GetMemorabiliaItemsPaged(int UserId, PageInfo PageInfo, MemorabiliaSearchCriteria MemorabiliaSearchCriteria = null) 
    : IQuery<MemorabiliaItemsModel>
{
    public class Handler : QueryHandler<GetMemorabiliaItemsPaged, MemorabiliaItemsModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<MemorabiliaItemsModel> Handle(GetMemorabiliaItemsPaged query)
        {
            var result = await _memorabiliaRepository.GetAll(query.UserId, query.PageInfo, query.MemorabiliaSearchCriteria);

            return new MemorabiliaItemsModel(result.Data, result.PageInfo);
        }
    }
}
