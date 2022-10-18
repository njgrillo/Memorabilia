using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.AcquisitionTypes;

public record GetAcquisitionType(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetAcquisitionType, DomainViewModel>
    {
        private readonly IDomainRepository<AcquisitionType> _acquisitionTypeRepository;

        public Handler(IDomainRepository<AcquisitionType> acquisitionTypeRepository)
        {
            _acquisitionTypeRepository = acquisitionTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetAcquisitionType query)
        {
            return new DomainViewModel(await _acquisitionTypeRepository.Get(query.Id));
        }
    }
}
