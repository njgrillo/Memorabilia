namespace Memorabilia.Application.Features.PrivateSigning;

public record GetPrivateSignings(PageInfo PageInfo)
    : IQuery<PrivateSigningsModel>
{
    public class Handler(IPrivateSigningRepository privateSigningRepository) 
        : QueryHandler<GetPrivateSignings, PrivateSigningsModel>
    {
        protected override async Task<PrivateSigningsModel> Handle(GetPrivateSignings query)
        {
            PagedResult<Entity.PrivateSigning> result
                = await privateSigningRepository.GetAll(query.PageInfo);

            return new PrivateSigningsModel(result.Data, result.PageInfo);
        }
    }
}
