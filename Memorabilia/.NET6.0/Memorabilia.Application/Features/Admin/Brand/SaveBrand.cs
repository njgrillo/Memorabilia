using Framework.Handler;
using Memorabilia.Domain;

namespace Memorabilia.Application.Features.Admin.Brand
{
    public class SaveBrand
    {
        public class Handler : CommandHandler<DomainEntityCommand>
        {
            private readonly IBrandRepository _brandRepository;

            public Handler(IBrandRepository brandRepository)
            {
                _brandRepository = brandRepository;
            }

            protected override async Task Handle(DomainEntityCommand command)
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
    }
}
