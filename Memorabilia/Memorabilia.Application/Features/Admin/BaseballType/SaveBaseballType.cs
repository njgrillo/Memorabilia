using Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.BaseballType
{
    public class SaveBaseballType
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IBaseballTypeRepository _baseballTypeRepository;

            public Handler(IBaseballTypeRepository baseballTypeRepository)
            {
                _baseballTypeRepository = baseballTypeRepository;
            }

            protected override async Task Handle(Command command)
            {
                Domain.Entities.BaseballType baseballType;

                if (command.IsNew)
                {
                    baseballType = new Domain.Entities.BaseballType(command.Name, command.Abbreviation);
                    await _baseballTypeRepository.Add(baseballType).ConfigureAwait(false);

                    return;
                }

                baseballType = await _baseballTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _baseballTypeRepository.Delete(baseballType).ConfigureAwait(false);

                    return;
                }

                baseballType.Set(command.Name, command.Abbreviation);

                await _baseballTypeRepository.Update(baseballType).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel)
            {
            }
        }
    }
}
