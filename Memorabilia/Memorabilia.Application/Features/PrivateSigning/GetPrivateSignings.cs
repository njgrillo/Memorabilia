namespace Memorabilia.Application.Features.PrivateSigning;

public record GetPrivateSignings(PageInfo PageInfo)
    : IQuery<PrivateSigningsModel>
{
    public class Handler : QueryHandler<GetPrivateSignings, PrivateSigningsModel>
    {
        private readonly IPrivateSigningRepository _privateSigningRepository;

        public Handler(IPrivateSigningRepository privateSigningRepository)
        {
            _privateSigningRepository = privateSigningRepository;
        }

        protected override async Task<PrivateSigningsModel> Handle(GetPrivateSignings query)
        {
            PagedResult<Entity.PrivateSigning> result
                = await _privateSigningRepository.GetAll(query.PageInfo);

            return new PrivateSigningsModel(result.Data, result.PageInfo);
        }
    }
}
