namespace Memorabilia.Application.Features.Admin.FigureTypes;

public record GetFigureTypes() : IQuery<Entity.FigureType[]>
{
    public class Handler(IDomainRepository<Entity.FigureType> figureTypeRepository) 
        : QueryHandler<GetFigureTypes, Entity.FigureType[]>
    {
        protected override async Task<Entity.FigureType[]> Handle(GetFigureTypes query)
            => await figureTypeRepository.GetAll();
    }
}
