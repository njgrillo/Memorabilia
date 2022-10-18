using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Franchises;

public record SaveFranchise(SaveFranchiseViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveFranchise>
    {
        private readonly IDomainRepository<Franchise> _franchiseRepository;

        public Handler(IDomainRepository<Franchise> franchiseRepository)
        {
            _franchiseRepository = franchiseRepository;
        }

        protected override async Task Handle(SaveFranchise request)
        {
            Franchise franchise;

            if (request.ViewModel.IsNew)
            {
                franchise = new Franchise(request.ViewModel.SportLeagueLevelId,
                                          request.ViewModel.Name,
                                          request.ViewModel.Location,
                                          request.ViewModel.FoundYear);

                await _franchiseRepository.Add(franchise);

                return;
            }

            franchise = await _franchiseRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _franchiseRepository.Delete(franchise);

                return;
            }

            franchise.Set(request.ViewModel.Name, request.ViewModel.Location, request.ViewModel.FoundYear);

            await _franchiseRepository.Update(franchise);
        }
    }
}
