namespace Memorabilia.Application.Features.Admin.Sports;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveSport(SportEditModel Sport) : ICommand
{
    public class Handler(IDomainRepository<Entity.Sport> sportRepository) 
        : CommandHandler<SaveSport>
    {
        protected override async Task Handle(SaveSport request)
        {
            Entity.Sport sport;

            if (request.Sport.IsNew)
            {
                sport = new Entity.Sport(request.Sport.Name, 
                                         request.Sport.AlternateName);

                await sportRepository.Add(sport);

                return;
            }

            sport = await sportRepository.Get(request.Sport.Id);

            if (request.Sport.IsDeleted)
            {
                await sportRepository.Delete(sport);

                return;
            }

            sport.Set(request.Sport.Name, 
                      request.Sport.AlternateName);

            await sportRepository.Update(sport);
        }
    }
}
