namespace Memorabilia.Application.Features.Admin.Colors;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetColor(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetColor, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.Color> _colorRepository;

        public Handler(IDomainRepository<Entity.Color> colorRepository)
        {
            _colorRepository = colorRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetColor query)
            => await _colorRepository.Get(query.Id);
    }
}
