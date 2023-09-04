namespace Memorabilia.Application.Features.Admin.Conditions;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record SaveCondition(DomainEditModel Condition) : ICommand
{
    public class Handler : CommandHandler<SaveCondition>
    {
        private readonly IDomainRepository<Entity.Condition> _conditionRepository;

        public Handler(IDomainRepository<Entity.Condition> conditionRepository)
        {
            _conditionRepository = conditionRepository;
        }

        protected override async Task Handle(SaveCondition request)
        {
            Entity.Condition condition;

            if (request.Condition.IsNew)
            {
                condition = new Entity.Condition(request.Condition.Name, 
                                                 request.Condition.Abbreviation);

                await _conditionRepository.Add(condition);

                return;
            }

            condition = await _conditionRepository.Get(request.Condition.Id);

            if (request.Condition.IsDeleted)
            {
                await _conditionRepository.Delete(condition);

                return;
            }

            condition.Set(request.Condition.Name, 
                          request.Condition.Abbreviation);

            await _conditionRepository.Update(condition);
        }
    }
}
