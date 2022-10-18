using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.AwardTypes;

public record GetAwardTypes() : IQuery<AwardTypesViewModel>
{
    public class Handler : QueryHandler<GetAwardTypes, AwardTypesViewModel>
    {
        private readonly IDomainRepository<AwardType> _awardTypeRepository;

        public Handler(IDomainRepository<AwardType> awardTypeRepository)
        {
            _awardTypeRepository = awardTypeRepository;
        }

        protected override async Task<AwardTypesViewModel> Handle(GetAwardTypes query)
        {
            return new AwardTypesViewModel(await _awardTypeRepository.GetAll());
        }
    }
}
