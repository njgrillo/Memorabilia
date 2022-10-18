using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Sports;

public record SaveSport(SaveSportViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveSport>
    {
        private readonly IDomainRepository<Sport> _sportRepository;

        public Handler(IDomainRepository<Sport> sportRepository)
        {
            _sportRepository = sportRepository;
        }

        protected override async Task Handle(SaveSport request)
        {
            Sport sport;

            if (request.ViewModel.IsNew)
            {
                sport = new Sport(request.ViewModel.Name, request.ViewModel.AlternateName);

                await _sportRepository.Add(sport);

                return;
            }

            sport = await _sportRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _sportRepository.Delete(sport);

                return;
            }

            sport.Set(request.ViewModel.Name, request.ViewModel.AlternateName);

            await _sportRepository.Update(sport);
        }
    }
}
