namespace Memorabilia.Application.Features.Admin.AccomplishmentTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveAccomplishmentType(DomainEditModel AccomplishmentType) 
    : ICommand
{
    public class Handler(IDomainRepository<Entity.AccomplishmentType> accomplishmentTypeRepository) 
        : CommandHandler<SaveAccomplishmentType>
    {
        protected override async Task Handle(SaveAccomplishmentType request)
        {
            Entity.AccomplishmentType accomplishmentType;

            if (request.AccomplishmentType.IsNew)
            {
                accomplishmentType = new Entity.AccomplishmentType(request.AccomplishmentType.Name, 
                                                                   request.AccomplishmentType.Abbreviation);

                await accomplishmentTypeRepository.Add(accomplishmentType);

                return;
            }

            accomplishmentType = await accomplishmentTypeRepository.Get(request.AccomplishmentType.Id);

            if (request.AccomplishmentType.IsDeleted)
            {
                await accomplishmentTypeRepository.Delete(accomplishmentType);

                return;
            }

            accomplishmentType.Set(request.AccomplishmentType.Name, 
                                   request.AccomplishmentType.Abbreviation);

            await accomplishmentTypeRepository.Update(accomplishmentType);
        }
    }
}