using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.BaseballTypes;

public record GetBaseballTypes() : IQuery<BaseballTypesViewModel>
{
    public class Handler : QueryHandler<GetBaseballTypes, BaseballTypesViewModel>
    {
        private readonly IDomainRepository<BaseballType> _baseballTypeRepository;

        public Handler(IDomainRepository<BaseballType> baseballTypeRepository)
        {
            _baseballTypeRepository = baseballTypeRepository;
        }

        protected override async Task<BaseballTypesViewModel> Handle(GetBaseballTypes query)
        {
            return new BaseballTypesViewModel(await _baseballTypeRepository.GetAll());
        }
    }
}
