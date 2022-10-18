using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ChampionTypes;

public record SaveChampionType(SaveDomainViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveChampionType>
    {
        private readonly IDomainRepository<ChampionType> _championTypeRepository;

        public Handler(IDomainRepository<ChampionType> championTypeRepository)
        {
            _championTypeRepository = championTypeRepository;
        }

        protected override async Task Handle(SaveChampionType request)
        {
            ChampionType championType;

            if (request.ViewModel.IsNew)
            {
                championType = new ChampionType(request.ViewModel.Name, request.ViewModel.Abbreviation);

                await _championTypeRepository.Add(championType);

                return;
            }

            championType = await _championTypeRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _championTypeRepository.Delete(championType);

                return;
            }

            championType.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _championTypeRepository.Update(championType);
        }
    }
}
