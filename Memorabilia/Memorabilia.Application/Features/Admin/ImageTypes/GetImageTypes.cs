namespace Memorabilia.Application.Features.Admin.ImageTypes;

public record GetImageTypes() : IQuery<Entity.ImageType[]>
{
    public class Handler(IDomainRepository<Entity.ImageType> imageTypeRepository) 
        : QueryHandler<GetImageTypes, Entity.ImageType[]>
    {
        protected override async Task<Entity.ImageType[]> Handle(GetImageTypes query)
            => await imageTypeRepository.GetAll();
    }
}
