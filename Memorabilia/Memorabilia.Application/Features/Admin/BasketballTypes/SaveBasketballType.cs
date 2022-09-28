using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.BasketballTypes
{
    public class SaveBasketballType
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IBasketballTypeRepository _basketballTypeRepository;

            public Handler(IBasketballTypeRepository basketballTypeRepository)
            {
                _basketballTypeRepository = basketballTypeRepository;
            }

            protected override async Task Handle(Command command)
            {
                BasketballType basketballType;

                if (command.IsNew)
                {
                    basketballType = new BasketballType(command.Name, command.Abbreviation);
                    await _basketballTypeRepository.Add(basketballType).ConfigureAwait(false);

                    return;
                }

                basketballType = await _basketballTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _basketballTypeRepository.Delete(basketballType).ConfigureAwait(false);

                    return;
                }

                basketballType.Set(command.Name, command.Abbreviation);

                await _basketballTypeRepository.Update(basketballType).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
        }
    }
}
