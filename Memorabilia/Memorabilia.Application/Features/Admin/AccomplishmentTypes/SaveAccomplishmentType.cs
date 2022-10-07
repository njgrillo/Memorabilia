using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.AccomplishmentTypes;

public class SaveAccomplishmentType
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<AccomplishmentType> _accomplishmentTypeRepository;

        public Handler(IDomainRepository<AccomplishmentType> accomplishmentTypeRepository)
        {
            _accomplishmentTypeRepository = accomplishmentTypeRepository;
        }

        protected override async Task Handle(Command command)
        {
            AccomplishmentType accomplishmentType;

            if (command.IsNew)
            {
                accomplishmentType = new AccomplishmentType(command.Name, command.Abbreviation);

                await _accomplishmentTypeRepository.Add(accomplishmentType);

                return;
            }

            accomplishmentType = await _accomplishmentTypeRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _accomplishmentTypeRepository.Delete(accomplishmentType);

                return;
            }

            accomplishmentType.Set(command.Name, command.Abbreviation);

            await _accomplishmentTypeRepository.Update(accomplishmentType);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
