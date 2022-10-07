using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.AwardTypes;

public class SaveAwardType
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<AwardType> _awardTypeRepository;

        public Handler(IDomainRepository<AwardType> awardTypeRepository)
        {
            _awardTypeRepository = awardTypeRepository;
        }

        protected override async Task Handle(Command command)
        {
            AwardType awardType;

            if (command.IsNew)
            {
                awardType = new AwardType(command.Name, command.Abbreviation);

                await _awardTypeRepository.Add(awardType);

                return;
            }

            awardType = await _awardTypeRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _awardTypeRepository.Delete(awardType);

                return;
            }

            awardType.Set(command.Name, command.Abbreviation);

            await _awardTypeRepository.Update(awardType);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
