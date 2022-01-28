using Framework.Handler;
using Memorabilia.Domain;

namespace Memorabilia.Application.Features.Admin.JerseyType
{
    public class SaveJerseyType
    {
        public class Handler : CommandHandler<DomainEntityCommand>
        {
            private readonly IJerseyTypeRepository _jerseyTypeRepository;

            public Handler(IJerseyTypeRepository jerseyTypeRepository)
            {
                _jerseyTypeRepository = jerseyTypeRepository;
            }

            protected override async Task Handle(DomainEntityCommand command)
            {
                Domain.Entities.JerseyType jerseyType;

                if (command.IsNew)
                {
                    jerseyType = new Domain.Entities.JerseyType(command.Name, command.Abbreviation);
                    await _jerseyTypeRepository.Add(jerseyType).ConfigureAwait(false);

                    return;
                }

                jerseyType = await _jerseyTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _jerseyTypeRepository.Delete(jerseyType).ConfigureAwait(false);

                    return;
                }

                jerseyType.Set(command.Name, command.Abbreviation);

                await _jerseyTypeRepository.Update(jerseyType).ConfigureAwait(false);
            }
        }
    }
}
