namespace Memorabilia.Application.Features.Admin.FigureSpecialtyTypes;

public record GetFigureSpecialtyTypes() : IQuery<Entity.FigureSpecialtyType[]>
{
    public class Handler : QueryHandler<GetFigureSpecialtyTypes, Entity.FigureSpecialtyType[]>
    {
        private readonly IDomainRepository<Entity.FigureSpecialtyType> _figureSpecialtyTypeRepository;

        public Handler(IDomainRepository<Entity.FigureSpecialtyType> figureSpecialtyTypeRepository)
        {
            _figureSpecialtyTypeRepository = figureSpecialtyTypeRepository;
        }

        protected override async Task<Entity.FigureSpecialtyType[]> Handle(GetFigureSpecialtyTypes query)
            => (await _figureSpecialtyTypeRepository.GetAll())
                    .ToArray();
    }
}
