using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ItemTypeSports;

public record SaveItemTypeSport(SaveItemTypeSportViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveItemTypeSport>
    {
        private readonly IItemTypeSportRepository _itemTypeSportRepository;

        public Handler(IItemTypeSportRepository itemTypeSportRepository)
        {
            _itemTypeSportRepository = itemTypeSportRepository;
        }

        protected override async Task Handle(SaveItemTypeSport request)
        {
            ItemTypeSport itemTypeSport;

            if (request.ViewModel.IsNew)
            {
                itemTypeSport = new ItemTypeSport(request.ViewModel.ItemType.Id, request.ViewModel.SportId);

                await _itemTypeSportRepository.Add(itemTypeSport);

                return;
            }

            itemTypeSport = await _itemTypeSportRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _itemTypeSportRepository.Delete(itemTypeSport);

                return;
            }

            itemTypeSport.Set(request.ViewModel.SportId);

            await _itemTypeSportRepository.Update(itemTypeSport);
        }
    }
}
