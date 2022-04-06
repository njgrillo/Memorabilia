using Framework.Handler;
using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Colors
{
    public class SaveColor
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IColorRepository _colorRepository;

            public Handler(IColorRepository colorRepository)
            {
                _colorRepository = colorRepository;
            }

            protected override async Task Handle(Command command)
            {
                Color color;

                if (command.IsNew)
                {
                    color = new Color(command.Name, command.Abbreviation);
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

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
        }
    }
}
