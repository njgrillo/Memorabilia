using Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.JerseyQualityType
{
    public class SaveJerseyQualityType
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IJerseyQualityTypeRepository _jerseyQualityTypeRepository;

            public Handler(IJerseyQualityTypeRepository jerseyQualityTypeRepository)
            {
                _jerseyQualityTypeRepository = jerseyQualityTypeRepository;
            }

            protected override async Task Handle(Command command)
            {
                Domain.Entities.JerseyQualityType jerseyQualityType;

                if (command.IsNew)
                {
                    jerseyQualityType = new Domain.Entities.JerseyQualityType(command.Name, command.Abbreviation);
                    await _jerseyQualityTypeRepository.Add(jerseyQualityType).ConfigureAwait(false);

                    return;
                }

                jerseyQualityType = await _jerseyQualityTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _jerseyQualityTypeRepository.Delete(jerseyQualityType).ConfigureAwait(false);

                    return;
                }

                jerseyQualityType.Set(command.Name, command.Abbreviation);

                await _jerseyQualityTypeRepository.Update(jerseyQualityType).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
        }
    }
}
