using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Shared.Images;

public record GetAutographImagesById(int AutographId) : IQuery<AutographImage[]>
{
    public class Handler : QueryHandler<GetAutographImagesById, AutographImage[]>
    {
        private readonly IAutographImageRepository _autographImageRepository;

        public Handler(IAutographImageRepository AutographImageRepository)
        {
            _autographImageRepository = AutographImageRepository;
        }

        protected override async Task<AutographImage[]> Handle(GetAutographImagesById query)
        {
            return (await _autographImageRepository.GetAll(query.AutographId)).ToArray();
        }
    }
}
