namespace Memorabilia.Application.Features.Admin.Conditions;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveCondition(DomainEditModel Condition) : ICommand
{
    public class Handler(IDomainRepository<Entity.Condition> conditionRepository) 
        : CommandHandler<SaveCondition>
    {
        protected override async Task Handle(SaveCondition request)
        {
            Entity.Condition condition;

            if (request.Condition.IsNew)
            {
                condition = new Entity.Condition(request.Condition.Name, 
                                                 request.Condition.Abbreviation);

                await conditionRepository.Add(condition);

                return;
            }

            condition = await conditionRepository.Get(request.Condition.Id);

            if (request.Condition.IsDeleted)
            {
                await conditionRepository.Delete(condition);

                return;
            }

            condition.Set(request.Condition.Name, 
                          request.Condition.Abbreviation);

            await conditionRepository.Update(condition);
        }
    }
}
