using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.JerseyQualityTypes;

public record GetJerseyQualityType(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetJerseyQualityType, DomainModel>
    {
        private readonly IDomainRepository<JerseyQualityType> _jerseyQualityTypeRepository;

        public Handler(IDomainRepository<JerseyQualityType> jerseyQualityTypeRepository)
        {
            _jerseyQualityTypeRepository = jerseyQualityTypeRepository;
        }

        protected override async Task<DomainModel> Handle(GetJerseyQualityType query)
        {
            return new DomainModel(await _jerseyQualityTypeRepository.Get(query.Id));
        }
    }
}
