namespace Memorabilia.Application.Features.Admin.ItemTypeSports;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveItemTypeSport(ItemTypeSportEditModel ItemTypeSport) : ICommand
{
    public class Handler(IItemTypeSportRepository itemTypeSportRepository) 
        : CommandHandler<SaveItemTypeSport>
    {
        protected override async Task Handle(SaveItemTypeSport request)
        {
            Entity.ItemTypeSport itemTypeSport;

            if (request.ItemTypeSport.IsNew)
            {
                itemTypeSport = new Entity.ItemTypeSport(request.ItemTypeSport.ItemType.Id, 
                                                         request.ItemTypeSport.SportId);

                await itemTypeSportRepository.Add(itemTypeSport);

                return;
            }

            itemTypeSport = await itemTypeSportRepository.Get(request.ItemTypeSport.Id);

            if (request.ItemTypeSport.IsDeleted)
            {
                await itemTypeSportRepository.Delete(itemTypeSport);

                return;
            }

            itemTypeSport.Set(request.ItemTypeSport.SportId);

            await itemTypeSportRepository.Update(itemTypeSport);
        }
    }
}
