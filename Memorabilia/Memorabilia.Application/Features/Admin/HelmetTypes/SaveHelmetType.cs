using Framework.Handler;
using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.HelmetTypes
{
    public class SaveHelmetType
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IHelmetTypeRepository _helmetTypeRepository;

            public Handler(IHelmetTypeRepository helmetTypeRepository)
            {
                _helmetTypeRepository = helmetTypeRepository;
            }

            protected override async Task Handle(Command command)
            {
                HelmetType helmetType;

                if (command.IsNew)
                {
                    helmetType = new HelmetType(command.Name, command.Abbreviation);
                    await _helmetTypeRepository.Add(helmetType).ConfigureAwait(false);

                    return;
                }

                helmetType = await _helmetTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _helmetTypeRepository.Delete(helmetType).ConfigureAwait(false);

                    return;
                }

                helmetType.Set(command.Name, command.Abbreviation);

                await _helmetTypeRepository.Update(helmetType).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
        }
    }
}
