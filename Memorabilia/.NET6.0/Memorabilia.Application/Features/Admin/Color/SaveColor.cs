using Framework.Handler;
using Memorabilia.Domain;

namespace Memorabilia.Application.Features.Admin.Color
{
    public class SaveColor
    {
        public class Handler : CommandHandler<DomainEntityCommand>
        {
            private readonly IColorRepository _colorRepository;

            public Handler(IColorRepository colorRepository)
            {
                _colorRepository = colorRepository;
            }

            protected override async Task Handle(DomainEntityCommand command)
            {
                Domain.Entities.Color color;

                if (command.IsNew)
                {
                    color = new Domain.Entities.Color(command.Name, command.Abbreviation);
                    await _colorRepository.Add(color).ConfigureAwait(false);

                    return;
                }

                color = await _colorRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _colorRepository.Delete(color).ConfigureAwait(false);

                    return;
                }

                color.Set(command.Name, command.Abbreviation);

                await _colorRepository.Update(color).ConfigureAwait(false);
            }
        }
    }
}
