using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.FigureSpecialtyTypes;

public record GetFigureSpecialtyType(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetFigureSpecialtyType, DomainModel>
    {
        private readonly IDomainRepository<FigureSpecialtyType> _figureSpecialtyTypeRepository;

        public Handler(IDomainRepository<FigureSpecialtyType> figureSpecialtyTypeRepository)
        {
            _figureSpecialtyTypeRepository = figureSpecialtyTypeRepository;
        }

        protected override async Task<DomainModel> Handle(GetFigureSpecialtyType query)
        {
            return new DomainModel(await _figureSpecialtyTypeRepository.Get(query.Id));
        }
    }
}
