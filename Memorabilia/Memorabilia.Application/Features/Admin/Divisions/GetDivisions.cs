using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Divisions;

public record GetDivisions() : IQuery<DivisionsViewModel>
{
    public class Handler : QueryHandler<GetDivisions, DivisionsViewModel>
    {
        private readonly IDomainRepository<Division> _divisionRepository;

        public Handler(IDomainRepository<Division> divisionRepository)
        {
            _divisionRepository = divisionRepository;
        }

        protected override async Task<DivisionsViewModel> Handle(GetDivisions query)
        {
            return new DivisionsViewModel(await _divisionRepository.GetAll());
        }
    }
}
