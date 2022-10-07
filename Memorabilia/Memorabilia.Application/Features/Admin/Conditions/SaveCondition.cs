using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Conditions;

public class SaveCondition
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<Condition> _conditionRepository;

        public Handler(IDomainRepository<Condition> conditionRepository)
        {
            _conditionRepository = conditionRepository;
        }

        protected override async Task Handle(Command command)
        {
            Condition condition;

            if (command.IsNew)
            {
                condition = new Condition(command.Name, command.Abbreviation);

                await _conditionRepository.Add(condition);

                return;
            }

            condition = await _conditionRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _conditionRepository.Delete(condition);

                return;
            }

            condition.Set(command.Name, command.Abbreviation);

            await _conditionRepository.Update(condition);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
