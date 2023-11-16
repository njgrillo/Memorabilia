namespace Memorabilia.Application.Features.Admin.PhotoTypes;

public record GetPhotoTypes() : IQuery<Entity.PhotoType[]>
{
    public class Handler(IDomainRepository<Entity.PhotoType> photoTypeRepository) 
        : QueryHandler<GetPhotoTypes, Entity.PhotoType[]>
    {
        protected override async Task<Entity.PhotoType[]> Handle(GetPhotoTypes query)
            => await photoTypeRepository.GetAll();
    }
}
