using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.PriorityTypes
{
    public class SavePriorityType
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IPriorityTypeRepository _priorityTypeRepository;

            public Handler(IPriorityTypeRepository priorityTypeRepository)
            {
                _priorityTypeRepository = priorityTypeRepository;
            }

            protected override async Task Handle(Command command)
            {
                PriorityType priorityType;

                if (command.IsNew)
                {
                    priorityType = new PriorityType(command.Name, command.Abbreviation);
                    await _priorityTypeRepository.Add(priorityType).ConfigureAwait(false);

                    return;
                }

                priorityType = await _priorityTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _priorityTypeRepository.Delete(priorityType).ConfigureAwait(false);

                    return;
                }

                priorityType.Set(command.Name, command.Abbreviation);

                await _priorityTypeRepository.Update(priorityType).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
        }
    }
}
