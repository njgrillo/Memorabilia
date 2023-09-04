namespace Memorabilia.Application.Features.Admin.FigureTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetFigureTypes() : IQuery<Entity.FigureType[]>
{
    public class Handler : QueryHandler<GetFigureTypes, Entity.FigureType[]>
    {
        private readonly IDomainRepository<Entity.FigureType> _figureTypeRepository;

        public Handler(IDomainRepository<Entity.FigureType> figureTypeRepository)
        {
            _figureTypeRepository = figureTypeRepository;
        }

        protected override async Task<Entity.FigureType[]> Handle(GetFigureTypes query)
            => await _figureTypeRepository.GetAll();
    }
}
