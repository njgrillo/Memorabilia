namespace Memorabilia.Application.Features.Admin.HelmetTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetHelmetTypes() : IQuery<Entity.HelmetType[]>
{
    public class Handler : QueryHandler<GetHelmetTypes, Entity.HelmetType[]>
    {
        private readonly IDomainRepository<Entity.HelmetType> _helmetTypeRepository;

        public Handler(IDomainRepository<Entity.HelmetType> helmetTypeRepository)
        {
            _helmetTypeRepository = helmetTypeRepository;
        }

        protected override async Task<Entity.HelmetType[]> Handle(GetHelmetTypes query)
            => await _helmetTypeRepository.GetAll();
    }
}
