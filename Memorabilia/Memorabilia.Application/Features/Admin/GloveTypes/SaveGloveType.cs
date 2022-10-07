using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.GloveTypes;

public class SaveGloveType
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<GloveType> _gloveTypeRepository;

        public Handler(IDomainRepository<GloveType> gloveTypeRepository)
        {
            _gloveTypeRepository = gloveTypeRepository;
        }

        protected override async Task Handle(Command command)
        {
            GloveType gloveType;

            if (command.IsNew)
            {
                gloveType = new GloveType(command.Name, command.Abbreviation);
                await _gloveTypeRepository.Add(gloveType);

                return;
            }

            gloveType = await _gloveTypeRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _gloveTypeRepository.Delete(gloveType);

                return;
            }

            gloveType.Set(command.Name, command.Abbreviation);

            await _gloveTypeRepository.Update(gloveType);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
