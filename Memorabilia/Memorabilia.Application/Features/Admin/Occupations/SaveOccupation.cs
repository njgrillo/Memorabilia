using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Occupations
{
    public class SaveOccupation
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IOccupationRepository _occupationRepository;

            public Handler(IOccupationRepository occupationRepository)
            {
                _occupationRepository = occupationRepository;
            }

            protected override async Task Handle(Command command)
            {
                Occupation occupation;

                if (command.IsNew)
                {
                    occupation = new Occupation(command.Name, command.Abbreviation);
                    await _occupationRepository.Add(occupation).ConfigureAwait(false);

                    return;
                }

                occupation = await _occupationRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _occupationRepository.Delete(occupation).ConfigureAwait(false);

                    return;
                }

                occupation.Set(command.Name, command.Abbreviation);

                await _occupationRepository.Update(occupation).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
        }
    }
}
