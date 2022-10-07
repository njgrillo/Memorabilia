using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.JerseyQualityTypes;

public class SaveJerseyQualityType
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<JerseyQualityType> _jerseyQualityTypeRepository;

        public Handler(IDomainRepository<JerseyQualityType> jerseyQualityTypeRepository)
        {
            _jerseyQualityTypeRepository = jerseyQualityTypeRepository;
        }

        protected override async Task Handle(Command command)
        {
            JerseyQualityType jerseyQualityType;

            if (command.IsNew)
            {
                jerseyQualityType = new JerseyQualityType(command.Name, command.Abbreviation);

                await _jerseyQualityTypeRepository.Add(jerseyQualityType);

                return;
            }

            jerseyQualityType = await _jerseyQualityTypeRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _jerseyQualityTypeRepository.Delete(jerseyQualityType);

                return;
            }

            jerseyQualityType.Set(command.Name, command.Abbreviation);

            await _jerseyQualityTypeRepository.Update(jerseyQualityType);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
