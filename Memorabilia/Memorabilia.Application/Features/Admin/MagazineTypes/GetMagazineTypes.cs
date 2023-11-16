namespace Memorabilia.Application.Features.Admin.MagazineTypes;

public record GetMagazineTypes() : IQuery<Entity.MagazineType[]>
{
    public class Handler(IDomainRepository<Entity.MagazineType> magazineTypeRepository) 
        : QueryHandler<GetMagazineTypes, Entity.MagazineType[]>
    {
        protected override async Task<Entity.MagazineType[]> Handle(GetMagazineTypes query)
            => await magazineTypeRepository.GetAll();
    }
}
