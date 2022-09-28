using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.AwardTypes
{
    public class SaveAwardType
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IAwardTypeRepository _awardTypeRepository;

            public Handler(IAwardTypeRepository awardTypeRepository)
            {
                _awardTypeRepository = awardTypeRepository;
            }

            protected override async Task Handle(Command command)
            {
                AwardType awardType;

                if (command.IsNew)
                {
                    awardType = new AwardType(command.Name, command.Abbreviation);
                    await _awardTypeRepository.Add(awardType).ConfigureAwait(false);

                    return;
                }

                awardType = await _awardTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _awardTypeRepository.Delete(awardType).ConfigureAwait(false);

                    return;
                }

                awardType.Set(command.Name, command.Abbreviation);

                await _awardTypeRepository.Update(awardType).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
        }
    }
}
