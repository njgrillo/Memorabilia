using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.FigureTypes;

public record GetFigureType(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetFigureType, DomainViewModel>
    {
        private readonly IDomainRepository<FigureType> _figureTypeRepository;

        public Handler(IDomainRepository<FigureType> figureTypeRepository)
        {
            _figureTypeRepository = figureTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetFigureType query)
        {
            return new DomainViewModel(await _figureTypeRepository.Get(query.Id));
        }
    }
}
