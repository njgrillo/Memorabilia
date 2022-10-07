using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.BasketballTypes;

public class SaveBasketballType
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<BasketballType> _basketballTypeRepository;

        public Handler(IDomainRepository<BasketballType> basketballTypeRepository)
        {
            _basketballTypeRepository = basketballTypeRepository;
        }

        protected override async Task Handle(Command command)
        {
            BasketballType basketballType;

            if (command.IsNew)
            {
                basketballType = new BasketballType(command.Name, command.Abbreviation);

                await _basketballTypeRepository.Add(basketballType);

                return;
            }

            basketballType = await _basketballTypeRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _basketballTypeRepository.Delete(basketballType);

                return;
            }

            basketballType.Set(command.Name, command.Abbreviation);

            await _basketballTypeRepository.Update(basketballType);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
