namespace Memorabilia.Application.Features.ForSale;

public record GetForSaleMemorabiliaItemsPaged(PageInfo PageInfo,
                                              MemorabiliaSearchCriteria MemorabiliaSearchCriteria = null)
    : IQuery<ForSaleModel>
{
    public class Handler : QueryHandler<GetForSaleMemorabiliaItemsPaged, ForSaleModel>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IMemorabiliaForSaleRepository _memorabiliaForSaleRepository;

        public Handler(IApplicationStateService applicationStateService,
            IMemorabiliaForSaleRepository memorabiliaForSaleRepository)
        {
            _applicationStateService = applicationStateService;
            _memorabiliaForSaleRepository = memorabiliaForSaleRepository;
        }

        protected override async Task<ForSaleModel> Handle(GetForSaleMemorabiliaItemsPaged query)
        {
            var result = await _memorabiliaForSaleRepository.GetAllForSale(_applicationStateService.CurrentUser.Id,
                                                                           query.PageInfo,
                                                                           query.MemorabiliaSearchCriteria);

            return new ForSaleModel(result.Data, result.PageInfo);
        }
    }
}
