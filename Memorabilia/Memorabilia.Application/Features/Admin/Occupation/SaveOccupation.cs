using Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Occupation
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
                Domain.Entities.Occupation occupation;

                if (command.IsNew)
                {
                    occupation = new Domain.Entities.Occupation(command.Name, command.Abbreviation);
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
