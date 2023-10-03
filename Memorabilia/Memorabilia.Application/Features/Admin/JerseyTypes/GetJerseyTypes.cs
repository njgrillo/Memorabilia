namespace Memorabilia.Application.Features.Admin.JerseyTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetJerseyTypes() : IQuery<Entity.JerseyType[]>
{
    public class Handler : QueryHandler<GetJerseyTypes, Entity.JerseyType[]>
    {
        private readonly IDomainRepository<Entity.JerseyType> _jerseyTypeRepository;

        public Handler(IDomainRepository<Entity.JerseyType> jerseyTypeRepository)
        {
            _jerseyTypeRepository = jerseyTypeRepository;
        }

        protected override async Task<Entity.JerseyType[]> Handle(GetJerseyTypes query)
            => await _jerseyTypeRepository.GetAll();
    }
}
