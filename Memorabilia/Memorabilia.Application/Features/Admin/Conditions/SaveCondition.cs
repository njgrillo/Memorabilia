using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Conditions;

public record SaveCondition(DomainEditModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveCondition>
    {
        private readonly IDomainRepository<Condition> _conditionRepository;

        public Handler(IDomainRepository<Condition> conditionRepository)
        {
            _conditionRepository = conditionRepository;
        }

        protected override async Task Handle(SaveCondition request)
        {
            Condition condition;

            if (request.ViewModel.IsNew)
            {
                condition = new Condition(request.ViewModel.Name, request.ViewModel.Abbreviation);

                await _conditionRepository.Add(condition);

                return;
            }

            condition = await _conditionRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _conditionRepository.Delete(condition);

                return;
            }

            condition.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _conditionRepository.Update(condition);
        }
    }
}
