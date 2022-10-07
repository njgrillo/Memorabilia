using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.BaseballTypes;

public class SaveBaseballType
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<BaseballType> _baseballTypeRepository;

        public Handler(IDomainRepository<BaseballType> baseballTypeRepository)
        {
            _baseballTypeRepository = baseballTypeRepository;
        }

        protected override async Task Handle(Command command)
        {
            BaseballType baseballType;

            if (command.IsNew)
            {
                baseballType = new BaseballType(command.Name, command.Abbreviation);

                await _baseballTypeRepository.Add(baseballType);

                return;
            }

            baseballType = await _baseballTypeRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _baseballTypeRepository.Delete(baseballType);

                return;
            }

            baseballType.Set(command.Name, command.Abbreviation);

            await _baseballTypeRepository.Update(baseballType);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
