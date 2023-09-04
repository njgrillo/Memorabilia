namespace Memorabilia.Application.Features.Admin.JerseyStyleTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record SaveJerseyStyleType(DomainEditModel JerseyStyleType) : ICommand
{
    public class Handler : CommandHandler<SaveJerseyStyleType>
    {
        private readonly IDomainRepository<Entity.JerseyStyleType> _jerseyStyleTypeRepository;

        public Handler(IDomainRepository<Entity.JerseyStyleType> jerseyStyleTypeRepository)
        {
            _jerseyStyleTypeRepository = jerseyStyleTypeRepository;
        }

        protected override async Task Handle(SaveJerseyStyleType request)
        {
            Entity.JerseyStyleType jerseyStyleType;

            if (request.JerseyStyleType.IsNew)
            {
                jerseyStyleType = new Entity.JerseyStyleType(request.JerseyStyleType.Name, 
                                                             request.JerseyStyleType.Abbreviation);

                await _jerseyStyleTypeRepository.Add(jerseyStyleType);

                return;
            }

            jerseyStyleType = await _jerseyStyleTypeRepository.Get(request.JerseyStyleType.Id);

            if (request.JerseyStyleType.IsDeleted)
            {
                await _jerseyStyleTypeRepository.Delete(jerseyStyleType);

                return;
            }

            jerseyStyleType.Set(request.JerseyStyleType.Name, 
                                request.JerseyStyleType.Abbreviation);

            await _jerseyStyleTypeRepository.Update(jerseyStyleType);
        }
    }
}
