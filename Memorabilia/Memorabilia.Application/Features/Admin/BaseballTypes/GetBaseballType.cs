using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.BaseballTypes;

public record GetBaseballType(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetBaseballType, DomainViewModel>
    {
        private readonly IDomainRepository<BaseballType> _baseballTypeRepository;

        public Handler(IDomainRepository<BaseballType> baseballTypeRepository)
        {
            _baseballTypeRepository = baseballTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetBaseballType query)
        {
            return new DomainViewModel(await _baseballTypeRepository.Get(query.Id));
        }
    }
}
