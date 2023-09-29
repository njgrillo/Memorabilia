namespace Memorabilia.Application.Features.PrivateSigning;

public record GetPrivateSigning(int PrivateSigningId)
    : IQuery<Entity.PrivateSigning>
{
    public class Handler : QueryHandler<GetPrivateSigning, Entity.PrivateSigning>
    {
        private readonly IPrivateSigningRepository _privateSigningRepository;

        public Handler(IPrivateSigningRepository privateSigningRepository)
        {
            _privateSigningRepository = privateSigningRepository;
        }

        protected override async Task<Entity.PrivateSigning> Handle(GetPrivateSigning query)
            => await _privateSigningRepository.Get(query.PrivateSigningId);
    }
}
