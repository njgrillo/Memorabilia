namespace Memorabilia.Application.Features.Admin.HelmetTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveHelmetType(DomainEditModel HelmetType) : ICommand
{
    public class Handler : CommandHandler<SaveHelmetType>
    {
        private readonly IDomainRepository<Entity.HelmetType> _helmetTypeRepository;

        public Handler(IDomainRepository<Entity.HelmetType> helmetTypeRepository)
        {
            _helmetTypeRepository = helmetTypeRepository;
        }

        protected override async Task Handle(SaveHelmetType request)
        {
            Entity.HelmetType helmetType;

            if (request.HelmetType.IsNew)
            {
                helmetType = new Entity.HelmetType(request.HelmetType.Name, 
                                                   request.HelmetType.Abbreviation);

                await _helmetTypeRepository.Add(helmetType);

                return;
            }

            helmetType = await _helmetTypeRepository.Get(request.HelmetType.Id);

            if (request.HelmetType.IsDeleted)
            {
                await _helmetTypeRepository.Delete(helmetType);

                return;
            }

            helmetType.Set(request.HelmetType.Name, 
                           request.HelmetType.Abbreviation);

            await _helmetTypeRepository.Update(helmetType);
        }
    }
}
