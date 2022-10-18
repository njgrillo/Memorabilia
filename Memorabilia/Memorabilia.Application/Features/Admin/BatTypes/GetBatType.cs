using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.BatTypes;

public record GetBatType(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetBatType, DomainViewModel>
    {
        private readonly IDomainRepository<BatType> _batTypeRepository;

        public Handler(IDomainRepository<BatType> batTypeRepository)
        {
            _batTypeRepository = batTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetBatType query)
        {
            return new DomainViewModel(await _batTypeRepository.Get(query.Id));
        }
    }
}
