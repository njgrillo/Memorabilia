using Framework.Handler;
using Memorabilia.Domain;

namespace Memorabilia.Application.Features.Admin.HelmetType
{
    public class SaveHelmetType
    {
        public class Handler : CommandHandler<DomainEntityCommand>
        {
            private readonly IHelmetTypeRepository _helmetTypeRepository;

            public Handler(IHelmetTypeRepository helmetTypeRepository)
            {
                _helmetTypeRepository = helmetTypeRepository;
            }

            protected override async Task Handle(DomainEntityCommand command)
            {
                Domain.Entities.HelmetType helmetType;

                if (command.IsNew)
                {
                    helmetType = new Domain.Entities.HelmetType(command.Name, command.Abbreviation);
                    await _helmetTypeRepository.Add(helmetType).ConfigureAwait(false);

                    return;
                }

                helmetType = await _helmetTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _helmetTypeRepository.Delete(helmetType).ConfigureAwait(false);

                    return;
                }

                helmetType.Set(command.Name, command.Abbreviation);

                await _helmetTypeRepository.Update(helmetType).ConfigureAwait(false);
            }
        }
    }
}
