namespace Memorabilia.Application.Features.Admin.LeaderTypes;

public record SaveLeaderType(DomainEditModel LeaderType) : ICommand
{
    public class Handler : CommandHandler<SaveLeaderType>
    {
        private readonly IDomainRepository<Entity.LeaderType> _leaderTypeRepository;

        public Handler(IDomainRepository<Entity.LeaderType> leaderTypeRepository)
        {
            _leaderTypeRepository = leaderTypeRepository;
        }

        protected override async Task Handle(SaveLeaderType request)
        {
            Entity.LeaderType leaderType;

            if (request.LeaderType.IsNew)
            {
                leaderType = new Entity.LeaderType(request.LeaderType.Name, 
                                                   request.LeaderType.Abbreviation);

                await _leaderTypeRepository.Add(leaderType);

                return;
            }

            leaderType = await _leaderTypeRepository.Get(request.LeaderType.Id);

            if (request.LeaderType.IsDeleted)
            {
                await _leaderTypeRepository.Delete(leaderType);

                return;
            }

            leaderType.Set(request.LeaderType.Name, 
                           request.LeaderType.Abbreviation);

            await _leaderTypeRepository.Update(leaderType);
        }
    }
}
