using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.LeaderTypes;

public record SaveLeaderType(SaveDomainViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveLeaderType>
    {
        private readonly IDomainRepository<LeaderType> _leaderTypeRepository;

        public Handler(IDomainRepository<LeaderType> leaderTypeRepository)
        {
            _leaderTypeRepository = leaderTypeRepository;
        }

        protected override async Task Handle(SaveLeaderType request)
        {
            LeaderType leaderType;

            if (request.ViewModel.IsNew)
            {
                leaderType = new LeaderType(request.ViewModel.Name, request.ViewModel.Abbreviation);

                await _leaderTypeRepository.Add(leaderType);

                return;
            }

            leaderType = await _leaderTypeRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _leaderTypeRepository.Delete(leaderType);

                return;
            }

            leaderType.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _leaderTypeRepository.Update(leaderType);
        }
    }
}
