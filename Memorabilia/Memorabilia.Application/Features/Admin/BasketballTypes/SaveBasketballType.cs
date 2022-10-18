using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.BasketballTypes;

public record SaveBasketballType(SaveDomainViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveBasketballType>
    {
        private readonly IDomainRepository<BasketballType> _basketballTypeRepository;

        public Handler(IDomainRepository<BasketballType> basketballTypeRepository)
        {
            _basketballTypeRepository = basketballTypeRepository;
        }

        protected override async Task Handle(SaveBasketballType request)
        {
            BasketballType basketballType;

            if (request.ViewModel.IsNew)
            {
                basketballType = new BasketballType(request.ViewModel.Name, request.ViewModel.Abbreviation);

                await _basketballTypeRepository.Add(basketballType);

                return;
            }

            basketballType = await _basketballTypeRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _basketballTypeRepository.Delete(basketballType);

                return;
            }

            basketballType.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _basketballTypeRepository.Update(basketballType);
        }
    }
}
