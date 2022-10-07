using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.AccomplishmentTypes;

public class GetAccomplishmentTypes
{
    public class Handler : QueryHandler<Query, AccomplishmentTypesViewModel>
    {
        private readonly IDomainRepository<AccomplishmentType> _accomplishmentTypeRepository;

        public Handler(IDomainRepository<AccomplishmentType> accomplishmentTypeRepository)
        {
            _accomplishmentTypeRepository = accomplishmentTypeRepository;
        }

        protected override async Task<AccomplishmentTypesViewModel> Handle(Query query)
        {
            return new AccomplishmentTypesViewModel(await _accomplishmentTypeRepository.GetAll());
        }
    }

    public class Query : IQuery<AccomplishmentTypesViewModel> { }
}
