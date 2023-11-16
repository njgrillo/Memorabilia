namespace Memorabilia.Application.Features.Admin.BaseballTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveBaseballType(DomainEditModel BaseballType) : ICommand
{
    public class Handler(IDomainRepository<Entity.BaseballType> baseballTypeRepository) 
        : CommandHandler<SaveBaseballType>
    {
        protected override async Task Handle(SaveBaseballType request)
        {
            Entity.BaseballType baseballType;

            if (request.BaseballType.IsNew)
            {
                baseballType = new Entity.BaseballType(request.BaseballType.Name, 
                                                       request.BaseballType.Abbreviation);

                await baseballTypeRepository.Add(baseballType);

                return;
            }

            baseballType = await baseballTypeRepository.Get(request.BaseballType.Id);

            if (request.BaseballType.IsDeleted)
            {
                await baseballTypeRepository.Delete(baseballType);

                return;
            }

            baseballType.Set(request.BaseballType.Name, 
                             request.BaseballType.Abbreviation);

            await baseballTypeRepository.Update(baseballType);
        }
    }
}
