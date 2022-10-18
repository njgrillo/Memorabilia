using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.FigureSpecialtyTypes;

public record GetFigureSpecialtyType(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetFigureSpecialtyType, DomainViewModel>
    {
        private readonly IDomainRepository<FigureSpecialtyType> _figureSpecialtyTypeRepository;

        public Handler(IDomainRepository<FigureSpecialtyType> figureSpecialtyTypeRepository)
        {
            _figureSpecialtyTypeRepository = figureSpecialtyTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetFigureSpecialtyType query)
        {
            return new DomainViewModel(await _figureSpecialtyTypeRepository.Get(query.Id));
        }
    }
}
