using Framework.Handler;
using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.HelmetFinishes
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
                HelmetFinish helmetFinish;

                if (command.IsNew)
                {
                    helmetFinish = new HelmetFinish(command.Name, command.Abbreviation);
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
