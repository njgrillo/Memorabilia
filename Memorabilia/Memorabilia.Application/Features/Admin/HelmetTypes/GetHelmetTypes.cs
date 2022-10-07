using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.HelmetTypes;

public class GetHelmetTypes
{
    public class Handler : QueryHandler<Query, HelmetTypesViewModel>
    {
        private readonly IDomainRepository<HelmetType> _helmetTypeRepository;

        public Handler(IDomainRepository<HelmetType> helmetTypeRepository)
        {
            _helmetTypeRepository = helmetTypeRepository;
        }

        protected override async Task<HelmetTypesViewModel> Handle(Query query)
        {
            return new HelmetTypesViewModel(await _helmetTypeRepository.GetAll());
        }
    }

    public class Query : IQuery<HelmetTypesViewModel> { }
}
