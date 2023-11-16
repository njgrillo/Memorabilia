namespace Memorabilia.Application.Features.Admin.HelmetTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveHelmetType(DomainEditModel HelmetType) : ICommand
{
    public class Handler(IDomainRepository<Entity.HelmetType> helmetTypeRepository) 
        : CommandHandler<SaveHelmetType>
    {
        protected override async Task Handle(SaveHelmetType request)
        {
            Entity.HelmetType helmetType;

            if (request.HelmetType.IsNew)
            {
                helmetType = new Entity.HelmetType(request.HelmetType.Name, 
                                                   request.HelmetType.Abbreviation);

                await helmetTypeRepository.Add(helmetType);

                return;
            }

            helmetType = await helmetTypeRepository.Get(request.HelmetType.Id);

            if (request.HelmetType.IsDeleted)
            {
                await helmetTypeRepository.Delete(helmetType);

                return;
            }

            helmetType.Set(request.HelmetType.Name, 
                           request.HelmetType.Abbreviation);

            await helmetTypeRepository.Update(helmetType);
        }
    }
}
