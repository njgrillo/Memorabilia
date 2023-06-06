using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.PrivacyTypes;

public record GetPrivacyType(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetPrivacyType, DomainModel>
    {
        private readonly IDomainRepository<PrivacyType> _privacyTypeRepository;

        public Handler(IDomainRepository<PrivacyType> privacyTypeRepository)
        {
            _privacyTypeRepository = privacyTypeRepository;
        }

        protected override async Task<DomainModel> Handle(GetPrivacyType query)
        {
            return new DomainModel(await _privacyTypeRepository.Get(query.Id));
        }
    }
}
