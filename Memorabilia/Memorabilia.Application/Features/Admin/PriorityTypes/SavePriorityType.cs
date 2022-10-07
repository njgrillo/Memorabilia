using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.PriorityTypes;

public class SavePriorityType
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<PriorityType> _priorityTypeRepository;

        public Handler(IDomainRepository<PriorityType> priorityTypeRepository)
        {
            _priorityTypeRepository = priorityTypeRepository;
        }

        protected override async Task Handle(Command command)
        {
            PriorityType priorityType;

            if (command.IsNew)
            {
                priorityType = new PriorityType(command.Name, command.Abbreviation);

                await _priorityTypeRepository.Add(priorityType);

                return;
            }

            priorityType = await _priorityTypeRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _priorityTypeRepository.Delete(priorityType);

                return;
            }

            priorityType.Set(command.Name, command.Abbreviation);

            await _priorityTypeRepository.Update(priorityType);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
