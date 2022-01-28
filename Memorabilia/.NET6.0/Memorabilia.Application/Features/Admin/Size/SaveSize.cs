using Framework.Handler;
using Memorabilia.Domain;

namespace Memorabilia.Application.Features.Admin.Size
{
    public class SaveSize
    {
        public class Handler : CommandHandler<DomainEntityCommand>
        {
            private readonly ISizeRepository _sizeRepository;

            public Handler(ISizeRepository sizeRepository)
            {
                _sizeRepository = sizeRepository;
            }

            protected override async Task Handle(DomainEntityCommand command)
            {
                Domain.Entities.Size size;

                if (command.IsNew)
                {
                    size = new Domain.Entities.Size(command.Name, command.Abbreviation);
                    await _sizeRepository.Add(size).ConfigureAwait(false);

                    return;
                }

                size = await _sizeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _sizeRepository.Delete(size).ConfigureAwait(false);

                    return;
                }

                size.Set(command.Name, command.Abbreviation);

                await _sizeRepository.Update(size).ConfigureAwait(false);
            }
        }
    }
}
