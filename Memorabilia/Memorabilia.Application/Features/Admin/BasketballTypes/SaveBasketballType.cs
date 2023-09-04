namespace Memorabilia.Application.Features.Admin.BasketballTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record SaveBasketballType(DomainEditModel BasketballType) : ICommand
{
    public class Handler : CommandHandler<SaveBasketballType>
    {
        private readonly IDomainRepository<Entity.BasketballType> _basketballTypeRepository;

        public Handler(IDomainRepository<Entity.BasketballType> basketballTypeRepository)
        {
            _basketballTypeRepository = basketballTypeRepository;
        }

        protected override async Task Handle(SaveBasketballType request)
        {
            Entity.BasketballType basketballType;

            if (request.BasketballType.IsNew)
            {
                basketballType = new Entity.BasketballType(request.BasketballType.Name, 
                                                           request.BasketballType.Abbreviation);

                await _basketballTypeRepository.Add(basketballType);

                return;
            }

            basketballType = await _basketballTypeRepository.Get(request.BasketballType.Id);

            if (request.BasketballType.IsDeleted)
            {
                await _basketballTypeRepository.Delete(basketballType);

                return;
            }

            basketballType.Set(request.BasketballType.Name, 
                               request.BasketballType.Abbreviation);

            await _basketballTypeRepository.Update(basketballType);
        }
    }
}
