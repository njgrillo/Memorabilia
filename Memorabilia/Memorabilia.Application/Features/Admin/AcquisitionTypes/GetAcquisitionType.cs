using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.AcquisitionTypes;

public record GetAcquisitionType(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetAcquisitionType, DomainModel>
    {
        private readonly IDomainRepository<AcquisitionType> _acquisitionTypeRepository;

        public Handler(IDomainRepository<AcquisitionType> acquisitionTypeRepository)
        {
            _acquisitionTypeRepository = acquisitionTypeRepository;
        }

        protected override async Task<DomainModel> Handle(GetAcquisitionType query)
        {
            return new DomainModel(await _acquisitionTypeRepository.Get(query.Id));
        }
    }
}
