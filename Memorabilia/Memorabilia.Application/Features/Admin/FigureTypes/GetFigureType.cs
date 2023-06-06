using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.FigureTypes;

public record GetFigureType(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetFigureType, DomainModel>
    {
        private readonly IDomainRepository<FigureType> _figureTypeRepository;

        public Handler(IDomainRepository<FigureType> figureTypeRepository)
        {
            _figureTypeRepository = figureTypeRepository;
        }

        protected override async Task<DomainModel> Handle(GetFigureType query)
        {
            return new DomainModel(await _figureTypeRepository.Get(query.Id));
        }
    }
}
