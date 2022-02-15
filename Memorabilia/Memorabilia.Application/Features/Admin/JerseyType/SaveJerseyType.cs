using Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.JerseyType
{
    public class SaveJerseyType
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IJerseyTypeRepository _jerseyTypeRepository;

            public Handler(IJerseyTypeRepository jerseyTypeRepository)
            {
                _jerseyTypeRepository = jerseyTypeRepository;
            }

            protected override async Task Handle(Command command)
            {
                Domain.Entities.JerseyType jerseyType;

                if (command.IsNew)
                {
                    jerseyType = new Domain.Entities.JerseyType(command.Name, command.Abbreviation);
                    await _jerseyTypeRepository.Add(jerseyType).ConfigureAwait(false);

                    return;
                }

                jerseyType = await _jerseyTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _jerseyTypeRepository.Delete(jerseyType).ConfigureAwait(false);

                    return;
                }

                jerseyType.Set(command.Name, command.Abbreviation);

                await _jerseyTypeRepository.Update(jerseyType).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
        }
    }
}
