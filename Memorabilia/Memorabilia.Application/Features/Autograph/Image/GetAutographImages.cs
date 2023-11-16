namespace Memorabilia.Application.Features.Autograph.Image;

public record GetAutographImages(int AutographId) : IQuery<Entity.AutographImage[]>
{
    public class Handler(IAutographImageRepository AutographImageRepository) 
        : QueryHandler<GetAutographImages, Entity.AutographImage[]>
    {
        protected override async Task<Entity.AutographImage[]> Handle(GetAutographImages query)
            => await AutographImageRepository.GetAll(query.AutographId);
    }
}
