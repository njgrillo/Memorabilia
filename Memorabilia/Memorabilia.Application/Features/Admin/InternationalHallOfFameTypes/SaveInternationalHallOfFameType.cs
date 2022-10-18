using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.InternationalHallOfFameTypes;

public record SaveInternationalHallOfFameType(SaveDomainViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveInternationalHallOfFameType>
    {
        private readonly IDomainRepository<InternationalHallOfFameType> _internationalHallOfFameTypeRepository;

        public Handler(IDomainRepository<InternationalHallOfFameType> internationalHallOfFameTypeRepository)
        {
            _internationalHallOfFameTypeRepository = internationalHallOfFameTypeRepository;
        }

        protected override async Task Handle(SaveInternationalHallOfFameType request)
        {
            InternationalHallOfFameType internationalHallOfFameType;

            if (request.ViewModel.IsNew)
            {
                internationalHallOfFameType = new InternationalHallOfFameType(request.ViewModel.Name, request.ViewModel.Abbreviation);

                await _internationalHallOfFameTypeRepository.Add(internationalHallOfFameType);

                return;
            }

            internationalHallOfFameType = await _internationalHallOfFameTypeRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _internationalHallOfFameTypeRepository.Delete(internationalHallOfFameType);

                return;
            }

            internationalHallOfFameType.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _internationalHallOfFameTypeRepository.Update(internationalHallOfFameType);
        }
    }
}
