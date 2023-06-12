namespace Memorabilia.Application.Features.Admin.MagazineTypes;

public record SaveMagazineType(DomainEditModel MagazineType) : ICommand
{
    public class Handler : CommandHandler<SaveMagazineType>
    {
        private readonly IDomainRepository<Entity.MagazineType> _magazineTypeRepository;

        public Handler(IDomainRepository<Entity.MagazineType> magazineTypeRepository)
        {
            _magazineTypeRepository = magazineTypeRepository;
        }

        protected override async Task Handle(SaveMagazineType request)
        {
            Entity.MagazineType magazineType;

            if (request.MagazineType.IsNew)
            {
                magazineType = new Entity.MagazineType(request.MagazineType.Name, 
                                                       request.MagazineType.Abbreviation);

                await _magazineTypeRepository.Add(magazineType);

                return;
            }

            magazineType = await _magazineTypeRepository.Get(request.MagazineType.Id);

            if (request.MagazineType.IsDeleted)
            {
                await _magazineTypeRepository.Delete(magazineType);

                return;
            }

            magazineType.Set(request.MagazineType.Name, 
                             request.MagazineType.Abbreviation);

            await _magazineTypeRepository.Update(magazineType);
        }
    }
}
