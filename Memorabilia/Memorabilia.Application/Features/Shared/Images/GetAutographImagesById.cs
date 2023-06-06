namespace Memorabilia.Application.Features.Shared.Images;

public record GetAutographImagesById(int AutographId) : IQuery<Entity.AutographImage[]>
{
    public class Handler : QueryHandler<GetAutographImagesById, Entity.AutographImage[]>
    {
        private readonly IAutographImageRepository _autographImageRepository;

        public Handler(IAutographImageRepository AutographImageRepository)
        {
            _autographImageRepository = AutographImageRepository;
        }

        protected override async Task<Entity.AutographImage[]> Handle(GetAutographImagesById query)
        {
            return (await _autographImageRepository.GetAll(query.AutographId)).ToArray();
        }
    }
}
