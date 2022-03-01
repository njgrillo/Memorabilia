using Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.HelmetFinish
{
    public class SaveHelmetFinish
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IHelmetFinishRepository _helmetFinishRepository;

            public Handler(IHelmetFinishRepository helmetFinishRepository)
            {
                _helmetFinishRepository = helmetFinishRepository;
            }

            protected override async Task Handle(Command command)
            {
                Domain.Entities.HelmetFinish helmetFinish;

                if (command.IsNew)
                {
                    helmetFinish = new Domain.Entities.HelmetFinish(command.Name, command.Abbreviation);
                    await _helmetFinishRepository.Add(helmetFinish).ConfigureAwait(false);

                    return;
                }

                helmetFinish = await _helmetFinishRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _helmetFinishRepository.Delete(helmetFinish).ConfigureAwait(false);

                    return;
                }

                helmetFinish.Set(command.Name, command.Abbreviation);

                await _helmetFinishRepository.Update(helmetFinish).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
        }
    }
}
