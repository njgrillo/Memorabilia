namespace Memorabilia.Application.Features.Admin.FigureTypes;

public record GetFigureType(int Id) : IQuery<Entity.FigureType>
{
    public class Handler : QueryHandler<GetFigureType, Entity.FigureType>
    {
        private readonly IDomainRepository<Entity.FigureType> _figureTypeRepository;

        public Handler(IDomainRepository<Entity.FigureType> figureTypeRepository)
        {
            _figureTypeRepository = figureTypeRepository;
        }

        protected override async Task<Entity.FigureType> Handle(GetFigureType query)
            => await _figureTypeRepository.Get(query.Id);
    }
}
