namespace Memorabilia.Application.Features.Admin.FigureSpecialtyTypes;

public record GetFigureSpecialtyType(int Id) : IQuery<Entity.FigureSpecialtyType>
{
    public class Handler : QueryHandler<GetFigureSpecialtyType, Entity.FigureSpecialtyType>
    {
        private readonly IDomainRepository<Entity.FigureSpecialtyType> _figureSpecialtyTypeRepository;

        public Handler(IDomainRepository<Entity.FigureSpecialtyType> figureSpecialtyTypeRepository)
        {
            _figureSpecialtyTypeRepository = figureSpecialtyTypeRepository;
        }

        protected override async Task<Entity.FigureSpecialtyType> Handle(GetFigureSpecialtyType query)
            => await _figureSpecialtyTypeRepository.Get(query.Id);
    }
}
