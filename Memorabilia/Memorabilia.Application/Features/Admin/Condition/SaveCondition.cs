using Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Condition
{
    public class SaveCondition
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IConditionRepository _conditionRepository;

            public Handler(IConditionRepository conditionRepository)
            {
                _conditionRepository = conditionRepository;
            }

            protected override async Task Handle(Command command)
            {
                Domain.Entities.Condition condition;

                if (command.IsNew)
                {
                    condition = new Domain.Entities.Condition(command.Name, command.Abbreviation);
                    await _conditionRepository.Add(condition).ConfigureAwait(false);

                    return;
                }

                condition = await _conditionRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _conditionRepository.Delete(condition).ConfigureAwait(false);

                    return;
                }

                condition.Set(command.Name, command.Abbreviation);

                await _conditionRepository.Update(condition).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
        }
    }
}
