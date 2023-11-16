namespace Memorabilia.Application.Features.Admin.MagazineTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveMagazineType(DomainEditModel MagazineType) : ICommand
{
    public class Handler(IDomainRepository<Entity.MagazineType> magazineTypeRepository) 
        : CommandHandler<SaveMagazineType>
    {
        protected override async Task Handle(SaveMagazineType request)
        {
            Entity.MagazineType magazineType;

            if (request.MagazineType.IsNew)
            {
                magazineType = new Entity.MagazineType(request.MagazineType.Name, 
                                                       request.MagazineType.Abbreviation);

                await magazineTypeRepository.Add(magazineType);

                return;
            }

            magazineType = await magazineTypeRepository.Get(request.MagazineType.Id);

            if (request.MagazineType.IsDeleted)
            {
                await magazineTypeRepository.Delete(magazineType);

                return;
            }

            magazineType.Set(request.MagazineType.Name, 
                             request.MagazineType.Abbreviation);

            await magazineTypeRepository.Update(magazineType);
        }
    }
}
