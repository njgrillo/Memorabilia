namespace Memorabilia.Application.Features.Admin.FigureSpecialtyTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetFigureSpecialtyType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetFigureSpecialtyType, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.FigureSpecialtyType> _figureSpecialtyTypeRepository;

        public Handler(IDomainRepository<Entity.FigureSpecialtyType> figureSpecialtyTypeRepository)
        {
            _figureSpecialtyTypeRepository = figureSpecialtyTypeRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetFigureSpecialtyType query)
            => await _figureSpecialtyTypeRepository.Get(query.Id);
    }
}
