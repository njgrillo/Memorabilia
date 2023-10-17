namespace Memorabilia.Application.Features.Admin.JerseyTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveJerseyType(DomainEditModel JerseyType) : ICommand
{
    public class Handler : CommandHandler<SaveJerseyType>
    {
        private readonly IDomainRepository<Entity.JerseyType> _jerseyTypeRepository;

        public Handler(IDomainRepository<Entity.JerseyType> jerseyTypeRepository)
        {
            _jerseyTypeRepository = jerseyTypeRepository;
        }

        protected override async Task Handle(SaveJerseyType request)
        {
            Entity.JerseyType jerseyType;

            if (request.JerseyType.IsNew)
            {
                jerseyType = new Entity.JerseyType(request.JerseyType.Name, 
                                                   request.JerseyType.Abbreviation);

                await _jerseyTypeRepository.Add(jerseyType);

                return;
            }

            jerseyType = await _jerseyTypeRepository.Get(request.JerseyType.Id);

            if (request.JerseyType.IsDeleted)
            {
                await _jerseyTypeRepository.Delete(jerseyType);

                return;
            }

            jerseyType.Set(request.JerseyType.Name, 
                           request.JerseyType.Abbreviation);

            await _jerseyTypeRepository.Update(jerseyType);
        }
    }
}
