using Framework.Handler;
using Memorabilia.Domain;

namespace Memorabilia.Application.Features.Admin.Condition
{
    public class SaveCondition
    {
        public class Handler : CommandHandler<DomainEntityCommand>
        {
            private readonly IConditionRepository _conditionRepository;

            public Handler(IConditionRepository conditionRepository)
            {
                _conditionRepository = conditionRepository;
            }

            protected override async Task Handle(DomainEntityCommand command)
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
    }
}
