using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.HelmetQualityTypes;

public record GetHelmetQualityType(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetHelmetQualityType, DomainModel>
    {
        private readonly IDomainRepository<HelmetQualityType> _helmetQualityTypeRepository;

        public Handler(IDomainRepository<HelmetQualityType> helmetQualityTypeRepository)
        {
            _helmetQualityTypeRepository = helmetQualityTypeRepository;
        }

        protected override async Task<DomainModel> Handle(GetHelmetQualityType query)
        {
            return new DomainModel(await _helmetQualityTypeRepository.Get(query.Id));
        }
    }
}
