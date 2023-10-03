namespace Memorabilia.Application.Features.Admin.GloveTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveGloveType(DomainEditModel GloveType) : ICommand
{
    public class Handler : CommandHandler<SaveGloveType>
    {
        private readonly IDomainRepository<Entity.GloveType> _gloveTypeRepository;

        public Handler(IDomainRepository<Entity.GloveType> gloveTypeRepository)
        {
            _gloveTypeRepository = gloveTypeRepository;
        }

        protected override async Task Handle(SaveGloveType request)
        {
            Entity.GloveType gloveType;

            if (request.GloveType.IsNew)
            {
                gloveType = new Entity.GloveType(request.GloveType.Name, 
                                                 request.GloveType.Abbreviation);

                await _gloveTypeRepository.Add(gloveType);

                return;
            }

            gloveType = await _gloveTypeRepository.Get(request.GloveType.Id);

            if (request.GloveType.IsDeleted)
            {
                await _gloveTypeRepository.Delete(gloveType);

                return;
            }

            gloveType.Set(request.GloveType.Name, 
                          request.GloveType.Abbreviation);

            await _gloveTypeRepository.Update(gloveType);
        }
    }
}
