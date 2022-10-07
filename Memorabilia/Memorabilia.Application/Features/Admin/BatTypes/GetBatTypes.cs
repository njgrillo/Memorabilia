using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.BatTypes;

public class GetBatTypes
{
    public class Handler : QueryHandler<Query, BatTypesViewModel>
    {
        private readonly IDomainRepository<BatType> _batTypeRepository;

        public Handler(IDomainRepository<BatType> batTypeRepository)
        {
            _batTypeRepository = batTypeRepository;
        }

        protected override async Task<BatTypesViewModel> Handle(Query query)
        {
            return new BatTypesViewModel(await _batTypeRepository.GetAll());
        }
    }

    public class Query : IQuery<BatTypesViewModel> { }
}
