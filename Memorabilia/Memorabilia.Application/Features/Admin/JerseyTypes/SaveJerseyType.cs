using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.JerseyTypes
{
    public class SaveJerseyType
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IJerseyTypeRepository _jerseyTypeRepository;

            public Handler(IJerseyTypeRepository jerseyTypeRepository)
            {
                _jerseyTypeRepository = jerseyTypeRepository;
            }

            protected override async Task Handle(Command command)
            {
                JerseyType jerseyType;

                if (command.IsNew)
                {
                    jerseyType = new JerseyType(command.Name, command.Abbreviation);
                    await _jerseyTypeRepository.Add(jerseyType).ConfigureAwait(false);

                    return;
                }

                jerseyType = await _jerseyTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _jerseyTypeRepository.Delete(jerseyType).ConfigureAwait(false);

                    return;
                }

                jerseyType.Set(command.Name, command.Abbreviation);

                await _jerseyTypeRepository.Update(jerseyType).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
        }
    }
}
