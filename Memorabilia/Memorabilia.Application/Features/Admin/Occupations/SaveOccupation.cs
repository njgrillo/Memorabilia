using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Occupations;

public class SaveOccupation
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<Occupation> _occupationRepository;

        public Handler(IDomainRepository<Occupation> occupationRepository)
        {
            _occupationRepository = occupationRepository;
        }

        protected override async Task Handle(Command command)
        {
            Occupation occupation;

            if (command.IsNew)
            {
                occupation = new Occupation(command.Name, command.Abbreviation);

                await _occupationRepository.Add(occupation);

                return;
            }

            occupation = await _occupationRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _occupationRepository.Delete(occupation);

                return;
            }

            occupation.Set(command.Name, command.Abbreviation);

            await _occupationRepository.Update(occupation);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
