using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.MagazineTypes;

public record SaveMagazineType(SaveDomainViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveMagazineType>
    {
        private readonly IDomainRepository<MagazineType> _magazineTypeRepository;

        public Handler(IDomainRepository<MagazineType> magazineTypeRepository)
        {
            _magazineTypeRepository = magazineTypeRepository;
        }

        protected override async Task Handle(SaveMagazineType request)
        {
            MagazineType magazineType;

            if (request.ViewModel.IsNew)
            {
                magazineType = new MagazineType(request.ViewModel.Name, request.ViewModel.Abbreviation);

                await _magazineTypeRepository.Add(magazineType);

                return;
            }

            magazineType = await _magazineTypeRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _magazineTypeRepository.Delete(magazineType);

                return;
            }

            magazineType.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _magazineTypeRepository.Update(magazineType);
        }
    }
}
