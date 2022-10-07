using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.HelmetQualityTypes;

public class SaveHelmetQualityType
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<HelmetQualityType> _helmetQualityTypeRepository;

        public Handler(IDomainRepository<HelmetQualityType> helmetQualityTypeRepository)
        {
            _helmetQualityTypeRepository = helmetQualityTypeRepository;
        }

        protected override async Task Handle(Command command)
        {
            HelmetQualityType helmetQualityType;

            if (command.IsNew)
            {
                helmetQualityType = new HelmetQualityType(command.Name, command.Abbreviation);

                await _helmetQualityTypeRepository.Add(helmetQualityType);

                return;
            }

            helmetQualityType = await _helmetQualityTypeRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _helmetQualityTypeRepository.Delete(helmetQualityType);

                return;
            }

            helmetQualityType.Set(command.Name, command.Abbreviation);

            await _helmetQualityTypeRepository.Update(helmetQualityType);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
