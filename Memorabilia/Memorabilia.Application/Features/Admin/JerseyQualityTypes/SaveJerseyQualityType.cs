namespace Memorabilia.Application.Features.Admin.JerseyQualityTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record SaveJerseyQualityType(DomainEditModel JerseyQualityType) : ICommand
{
    public class Handler : CommandHandler<SaveJerseyQualityType>
    {
        private readonly IDomainRepository<Entity.JerseyQualityType> _jerseyQualityTypeRepository;

        public Handler(IDomainRepository<Entity.JerseyQualityType> jerseyQualityTypeRepository)
        {
            _jerseyQualityTypeRepository = jerseyQualityTypeRepository;
        }

        protected override async Task Handle(SaveJerseyQualityType request)
        {
            Entity.JerseyQualityType jerseyQualityType;

            if (request.JerseyQualityType.IsNew)
            {
                jerseyQualityType = new Entity.JerseyQualityType(request.JerseyQualityType.Name, 
                                                                 request.JerseyQualityType.Abbreviation);

                await _jerseyQualityTypeRepository.Add(jerseyQualityType);

                return;
            }

            jerseyQualityType = await _jerseyQualityTypeRepository.Get(request.JerseyQualityType.Id);

            if (request.JerseyQualityType.IsDeleted)
            {
                await _jerseyQualityTypeRepository.Delete(jerseyQualityType);

                return;
            }

            jerseyQualityType.Set(request.JerseyQualityType.Name, 
                                  request.JerseyQualityType.Abbreviation);

            await _jerseyQualityTypeRepository.Update(jerseyQualityType);
        }
    }
}
