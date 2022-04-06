using Framework.Handler;
using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.HelmetQualityTypes
{
    public class SaveHelmetQualityType
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IHelmetQualityTypeRepository _helmetQualityTypeRepository;

            public Handler(IHelmetQualityTypeRepository helmetQualityTypeRepository)
            {
                _helmetQualityTypeRepository = helmetQualityTypeRepository;
            }

            protected override async Task Handle(Command command)
            {
                HelmetQualityType helmetQualityType;

                if (command.IsNew)
                {
                    helmetQualityType = new HelmetQualityType(command.Name, command.Abbreviation);
                    await _helmetQualityTypeRepository.Add(helmetQualityType).ConfigureAwait(false);

                    return;
                }

                helmetQualityType = await _helmetQualityTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _helmetQualityTypeRepository.Delete(helmetQualityType).ConfigureAwait(false);

                    return;
                }

                helmetQualityType.Set(command.Name, command.Abbreviation);

                await _helmetQualityTypeRepository.Update(helmetQualityType).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
        }
    }
}
