namespace Memorabilia.Application.Features.Admin.ItemTypeSports;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record SaveItemTypeSport(ItemTypeSportEditModel ItemTypeSport) : ICommand
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
            Entity.ItemTypeSport itemTypeSport;

            if (request.ItemTypeSport.IsNew)
            {
                itemTypeSport = new Entity.ItemTypeSport(request.ItemTypeSport.ItemType.Id, 
                                                         request.ItemTypeSport.SportId);

                await _itemTypeSportRepository.Add(itemTypeSport);

                return;
            }

            itemTypeSport = await _itemTypeSportRepository.Get(request.ItemTypeSport.Id);

            if (request.ItemTypeSport.IsDeleted)
            {
                await _itemTypeSportRepository.Delete(itemTypeSport);

                return;
            }

            itemTypeSport.Set(request.ItemTypeSport.SportId);

            await _itemTypeSportRepository.Update(itemTypeSport);
        }
    }
}
