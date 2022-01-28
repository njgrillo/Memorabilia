using Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Brand
{
    public class SaveBrand
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IBrandRepository _brandRepository;

            public Handler(IBrandRepository brandRepository)
            {
                _brandRepository = brandRepository;
            }

            protected override async Task Handle(Command command)
            {
                Domain.Entities.Brand brand;

                if (command.IsNew)
                {
                    brand = new Domain.Entities.Brand(command.Name, command.Abbreviation);
                    await _brandRepository.Add(brand).ConfigureAwait(false);

                    return;
                }

                brand = await _brandRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _brandRepository.Delete(brand).ConfigureAwait(false);

                    return;
                }

                brand.Set(command.Name, command.Abbreviation);

                await _brandRepository.Update(brand).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel)
            {
            }
        }
    }
}
