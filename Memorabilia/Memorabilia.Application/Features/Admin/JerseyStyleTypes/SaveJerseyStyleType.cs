using Framework.Handler;
using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.JerseyStyleTypes
{
    public class SaveJerseyStyleType
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IJerseyStyleTypeRepository _jerseyStyleTypeRepository;

            public Handler(IJerseyStyleTypeRepository jerseyStyleTypeRepository)
            {
                _jerseyStyleTypeRepository = jerseyStyleTypeRepository;
            }

            protected override async Task Handle(Command command)
            {
                JerseyStyleType jerseyStyleType;

                if (command.IsNew)
                {
                    jerseyStyleType = new JerseyStyleType(command.Name, command.Abbreviation);
                    await _jerseyStyleTypeRepository.Add(jerseyStyleType).ConfigureAwait(false);

                    return;
                }

                jerseyStyleType = await _jerseyStyleTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _jerseyStyleTypeRepository.Delete(jerseyStyleType).ConfigureAwait(false);

                    return;
                }

                jerseyStyleType.Set(command.Name, command.Abbreviation);

                await _jerseyStyleTypeRepository.Update(jerseyStyleType).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
        }
    }
}
