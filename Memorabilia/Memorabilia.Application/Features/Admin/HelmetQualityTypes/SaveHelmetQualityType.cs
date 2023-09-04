namespace Memorabilia.Application.Features.Admin.HelmetQualityTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record SaveHelmetQualityType(DomainEditModel HelmetQualityType) : ICommand
{
    public class Handler : CommandHandler<SaveHelmetQualityType>
    {
        private readonly IDomainRepository<Entity.HelmetQualityType> _helmetQualityTypeRepository;

        public Handler(IDomainRepository<Entity.HelmetQualityType> helmetQualityTypeRepository)
        {
            _helmetQualityTypeRepository = helmetQualityTypeRepository;
        }

        protected override async Task Handle(SaveHelmetQualityType request)
        {
            Entity.HelmetQualityType helmetQualityType;

            if (request.HelmetQualityType.IsNew)
            {
                helmetQualityType = new Entity.HelmetQualityType(request.HelmetQualityType.Name, 
                                                                 request.HelmetQualityType.Abbreviation);

                await _helmetQualityTypeRepository.Add(helmetQualityType);

                return;
            }

            helmetQualityType = await _helmetQualityTypeRepository.Get(request.HelmetQualityType.Id);

            if (request.HelmetQualityType.IsDeleted)
            {
                await _helmetQualityTypeRepository.Delete(helmetQualityType);

                return;
            }

            helmetQualityType.Set(request.HelmetQualityType.Name, 
                                  request.HelmetQualityType.Abbreviation);

            await _helmetQualityTypeRepository.Update(helmetQualityType);
        }
    }
}
