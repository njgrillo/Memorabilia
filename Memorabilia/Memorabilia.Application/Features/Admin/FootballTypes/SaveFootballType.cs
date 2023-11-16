namespace Memorabilia.Application.Features.Admin.FootballTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveFootballType(DomainEditModel FootballType) : ICommand
{
    public class Handler(IDomainRepository<Entity.FootballType> footballTypeRepository) 
        : CommandHandler<SaveFootballType>
    {
        protected override async Task Handle(SaveFootballType request)
        {
            Entity.FootballType footballType;

            if (request.FootballType.IsNew)
            {
                footballType = new Entity.FootballType(request.FootballType.Name, 
                                                       request.FootballType.Abbreviation);

                await footballTypeRepository.Add(footballType);

                return;
            }

            footballType = await footballTypeRepository.Get(request.FootballType.Id);

            if (request.FootballType.IsDeleted)
            {
                await footballTypeRepository.Delete(footballType);

                return;
            }

            footballType.Set(request.FootballType.Name, 
                             request.FootballType.Abbreviation);

            await footballTypeRepository.Update(footballType);
        }
    }
}
