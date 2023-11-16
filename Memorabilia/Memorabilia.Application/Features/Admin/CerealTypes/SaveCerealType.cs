namespace Memorabilia.Application.Features.Admin.CerealTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveCerealType(DomainEditModel CerealType) : ICommand
{
    public class Handler(IDomainRepository<Entity.CerealType> cerealTypeRepository) 
        : CommandHandler<SaveCerealType>
    {
        protected override async Task Handle(SaveCerealType request)
        {
            Entity.CerealType cerealType;

            if (request.CerealType.IsNew)
            {
                cerealType = new Entity.CerealType(request.CerealType.Name, 
                                                   request.CerealType.Abbreviation);

                await cerealTypeRepository.Add(cerealType);

                return;
            }

            cerealType = await cerealTypeRepository.Get(request.CerealType.Id);

            if (request.CerealType.IsDeleted)
            {
                await cerealTypeRepository.Delete(cerealType);

                return;
            }

            cerealType.Set(request.CerealType.Name, 
                           request.CerealType.Abbreviation);

            await cerealTypeRepository.Update(cerealType);
        }
    }
}
