namespace Memorabilia.Application.Features.PrivateSigning.Promoter;

public record GetPromoterPrivateSignings(PageInfo PageInfo)
    : IQuery<PromoterPrivateSigningsModel>
{
    public class Handler : QueryHandler<GetPromoterPrivateSignings, PromoterPrivateSigningsModel>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IPrivateSigningRepository _privateSigningRepository;

        public Handler(IApplicationStateService applicationStateService,
                       IPrivateSigningRepository privateSigningRepository)
        {
            _applicationStateService = applicationStateService;
            _privateSigningRepository = privateSigningRepository;
        }

        protected override async Task<PromoterPrivateSigningsModel> Handle(GetPromoterPrivateSignings query)
        {
            PagedResult<Entity.PrivateSigning> result
                = await _privateSigningRepository.GetAll(query.PageInfo, 
                                                         _applicationStateService.CurrentUser.Id);

            return new PromoterPrivateSigningsModel(result.Data, result.PageInfo);
        }
    }
}
