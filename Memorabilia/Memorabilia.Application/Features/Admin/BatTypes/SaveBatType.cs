namespace Memorabilia.Application.Features.Admin.BatTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveBatType(DomainEditModel BatType) : ICommand
{
    public class Handler(IDomainRepository<Entity.BatType> batTypeRepository) 
        : CommandHandler<SaveBatType>
    {
        protected override async Task Handle(SaveBatType request)
        {
            Entity.BatType batType;

            if (request.BatType.IsNew)
            {
                batType = new Entity.BatType(request.BatType.Name, 
                                             request.BatType.Abbreviation);

                await batTypeRepository.Add(batType);

                return;
            }

            batType = await batTypeRepository.Get(request.BatType.Id);

            if (request.BatType.IsDeleted)
            {
                await batTypeRepository.Delete(batType);

                return;
            }

            batType.Set(request.BatType.Name, 
                        request.BatType.Abbreviation);

            await batTypeRepository.Update(batType);
        }
    }
}
