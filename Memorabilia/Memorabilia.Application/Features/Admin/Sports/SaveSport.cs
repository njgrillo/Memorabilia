namespace Memorabilia.Application.Features.Admin.Sports;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveSport(SportEditModel Sport) : ICommand
{
    public class Handler : CommandHandler<SaveSport>
    {
        private readonly IDomainRepository<Entity.Sport> _sportRepository;

        public Handler(IDomainRepository<Entity.Sport> sportRepository)
        {
            _sportRepository = sportRepository;
        }

        protected override async Task Handle(SaveSport request)
        {
            Entity.Sport sport;

            if (request.Sport.IsNew)
            {
                sport = new Entity.Sport(request.Sport.Name, 
                                         request.Sport.AlternateName);

                await _sportRepository.Add(sport);

                return;
            }

            sport = await _sportRepository.Get(request.Sport.Id);

            if (request.Sport.IsDeleted)
            {
                await _sportRepository.Delete(sport);

                return;
            }

            sport.Set(request.Sport.Name, 
                      request.Sport.AlternateName);

            await _sportRepository.Update(sport);
        }
    }
}
