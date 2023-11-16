namespace Memorabilia.Application.Features.Admin.GloveTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveGloveType(DomainEditModel GloveType) : ICommand
{
    public class Handler(IDomainRepository<Entity.GloveType> gloveTypeRepository) 
        : CommandHandler<SaveGloveType>
    {
        protected override async Task Handle(SaveGloveType request)
        {
            Entity.GloveType gloveType;

            if (request.GloveType.IsNew)
            {
                gloveType = new Entity.GloveType(request.GloveType.Name, 
                                                 request.GloveType.Abbreviation);

                await gloveTypeRepository.Add(gloveType);

                return;
            }

            gloveType = await gloveTypeRepository.Get(request.GloveType.Id);

            if (request.GloveType.IsDeleted)
            {
                await gloveTypeRepository.Delete(gloveType);

                return;
            }

            gloveType.Set(request.GloveType.Name, 
                          request.GloveType.Abbreviation);

            await gloveTypeRepository.Update(gloveType);
        }
    }
}
