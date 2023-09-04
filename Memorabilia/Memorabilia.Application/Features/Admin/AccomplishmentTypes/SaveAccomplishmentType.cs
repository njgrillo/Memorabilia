namespace Memorabilia.Application.Features.Admin.AccomplishmentTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record SaveAccomplishmentType(DomainEditModel AccomplishmentType) : ICommand
{
    public class Handler : CommandHandler<SaveAccomplishmentType>
    {
        private readonly IDomainRepository<Entity.AccomplishmentType> _accomplishmentTypeRepository;

        public Handler(IDomainRepository<Entity.AccomplishmentType> accomplishmentTypeRepository)
        {
            _accomplishmentTypeRepository = accomplishmentTypeRepository;
        }

        protected override async Task Handle(SaveAccomplishmentType request)
        {
            Entity.AccomplishmentType accomplishmentType;

            if (request.AccomplishmentType.IsNew)
            {
                accomplishmentType = new Entity.AccomplishmentType(request.AccomplishmentType.Name, 
                                                                   request.AccomplishmentType.Abbreviation);

                await _accomplishmentTypeRepository.Add(accomplishmentType);

                return;
            }

            accomplishmentType = await _accomplishmentTypeRepository.Get(request.AccomplishmentType.Id);

            if (request.AccomplishmentType.IsDeleted)
            {
                await _accomplishmentTypeRepository.Delete(accomplishmentType);

                return;
            }

            accomplishmentType.Set(request.AccomplishmentType.Name, 
                                   request.AccomplishmentType.Abbreviation);

            await _accomplishmentTypeRepository.Update(accomplishmentType);
        }
    }
}