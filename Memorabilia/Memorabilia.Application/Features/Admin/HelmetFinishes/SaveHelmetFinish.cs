using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.HelmetFinishes;

public class SaveHelmetFinish
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<HelmetFinish> _helmetFinishRepository;

        public Handler(IDomainRepository<HelmetFinish> helmetFinishRepository)
        {
            _helmetFinishRepository = helmetFinishRepository;
        }

        protected override async Task Handle(Command command)
        {
            HelmetFinish helmetFinish;

            if (command.IsNew)
            {
                helmetFinish = new HelmetFinish(command.Name, command.Abbreviation);

                await _helmetFinishRepository.Add(helmetFinish);

                return;
            }

            helmetFinish = await _helmetFinishRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _helmetFinishRepository.Delete(helmetFinish);

                return;
            }

            helmetFinish.Set(command.Name, command.Abbreviation);

            await _helmetFinishRepository.Update(helmetFinish);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
