namespace Memorabilia.Application.Features.Admin.LeaderTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveLeaderType(DomainEditModel LeaderType) : ICommand
{
    public class Handler(IDomainRepository<Entity.LeaderType> leaderTypeRepository) 
        : CommandHandler<SaveLeaderType>
    {
        protected override async Task Handle(SaveLeaderType request)
        {
            Entity.LeaderType leaderType;

            if (request.LeaderType.IsNew)
            {
                leaderType = new Entity.LeaderType(request.LeaderType.Name, 
                                                   request.LeaderType.Abbreviation);

                await leaderTypeRepository.Add(leaderType);

                return;
            }

            leaderType = await leaderTypeRepository.Get(request.LeaderType.Id);

            if (request.LeaderType.IsDeleted)
            {
                await leaderTypeRepository.Delete(leaderType);

                return;
            }

            leaderType.Set(request.LeaderType.Name, 
                           request.LeaderType.Abbreviation);

            await leaderTypeRepository.Update(leaderType);
        }
    }
}
