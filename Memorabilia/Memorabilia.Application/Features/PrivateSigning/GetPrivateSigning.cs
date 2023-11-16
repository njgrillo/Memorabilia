namespace Memorabilia.Application.Features.PrivateSigning;

public record GetPrivateSigning(int PrivateSigningId)
    : IQuery<Entity.PrivateSigning>
{
    public class Handler(IPrivateSigningRepository privateSigningRepository) 
        : QueryHandler<GetPrivateSigning, Entity.PrivateSigning>
    {
        protected override async Task<Entity.PrivateSigning> Handle(GetPrivateSigning query)
            => await privateSigningRepository.Get(query.PrivateSigningId);
    }
}
