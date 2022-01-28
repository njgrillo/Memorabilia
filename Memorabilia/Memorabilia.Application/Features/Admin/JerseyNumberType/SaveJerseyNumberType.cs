using Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.JerseyNumberType
{
    public class SaveJerseyNumberType
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IJerseyNumberTypeRepository _jerseyNumberTypeRepository;

            public Handler(IJerseyNumberTypeRepository jerseyNumberTypeRepository)
            {
                _jerseyNumberTypeRepository = jerseyNumberTypeRepository;
            }

            protected override async Task Handle(Command command)
            {
                Domain.Entities.JerseyNumberType jerseyNumberType;

                if (command.IsNew)
                {
                    jerseyNumberType = new Domain.Entities.JerseyNumberType(command.Name, command.Abbreviation);
                    await _jerseyNumberTypeRepository.Add(jerseyNumberType).ConfigureAwait(false);

                    return;
                }

                jerseyNumberType = await _jerseyNumberTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _jerseyNumberTypeRepository.Delete(jerseyNumberType).ConfigureAwait(false);

                    return;
                }

                jerseyNumberType.Set(command.Name, command.Abbreviation);

                await _jerseyNumberTypeRepository.Update(jerseyNumberType).ConfigureAwait(false);
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
