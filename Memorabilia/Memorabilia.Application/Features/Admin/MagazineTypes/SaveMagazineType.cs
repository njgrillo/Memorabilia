using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.MagazineTypes;

public class SaveMagazineType
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<MagazineType> _magazineTypeRepository;

        public Handler(IDomainRepository<MagazineType> magazineTypeRepository)
        {
            _magazineTypeRepository = magazineTypeRepository;
        }

        protected override async Task Handle(Command command)
        {
            MagazineType magazineType;

            if (command.IsNew)
            {
                magazineType = new MagazineType(command.Name, command.Abbreviation);

                await _magazineTypeRepository.Add(magazineType);

                return;
            }

            magazineType = await _magazineTypeRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _magazineTypeRepository.Delete(magazineType);

                return;
            }

            magazineType.Set(command.Name, command.Abbreviation);

            await _magazineTypeRepository.Update(magazineType);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
