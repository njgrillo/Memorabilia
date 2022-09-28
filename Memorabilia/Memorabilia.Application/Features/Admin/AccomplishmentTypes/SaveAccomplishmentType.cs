using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.AccomplishmentTypes
{
    public class SaveAccomplishmentType
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IAccomplishmentTypeRepository _accomplishmentTypeRepository;

            public Handler(IAccomplishmentTypeRepository accomplishmentTypeRepository)
            {
                _accomplishmentTypeRepository = accomplishmentTypeRepository;
            }

            protected override async Task Handle(Command command)
            {
                AccomplishmentType accomplishmentType;

                if (command.IsNew)
                {
                    accomplishmentType = new AccomplishmentType(command.Name, command.Abbreviation);
                    await _accomplishmentTypeRepository.Add(accomplishmentType).ConfigureAwait(false);

                    return;
                }

                accomplishmentType = await _accomplishmentTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _accomplishmentTypeRepository.Delete(accomplishmentType).ConfigureAwait(false);

                    return;
                }

                accomplishmentType.Set(command.Name, command.Abbreviation);

                await _accomplishmentTypeRepository.Update(accomplishmentType).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
        }
    }
}
