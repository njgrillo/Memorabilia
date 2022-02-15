using Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.MagazineType
{
    public class SaveMagazineType
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IMagazineTypeRepository _magazineTypeRepository;

            public Handler(IMagazineTypeRepository magazineTypeRepository)
            {
                _magazineTypeRepository = magazineTypeRepository;
            }

            protected override async Task Handle(Command command)
            {
                Domain.Entities.MagazineType magazineType;

                if (command.IsNew)
                {
                    magazineType = new Domain.Entities.MagazineType(command.Name, command.Abbreviation);
                    await _magazineTypeRepository.Add(magazineType).ConfigureAwait(false);

                    return;
                }

                magazineType = await _magazineTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _magazineTypeRepository.Delete(magazineType).ConfigureAwait(false);

                    return;
                }

                magazineType.Set(command.Name, command.Abbreviation);

                await _magazineTypeRepository.Update(magazineType).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
        }
    }
}
