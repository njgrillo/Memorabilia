using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.AccomplishmentTypes;

public record GetAccomplishmentTypesQuery() : IQuery<AccomplishmentTypesViewModel>
{
    public class Handler : QueryHandler<GetAccomplishmentTypesQuery, AccomplishmentTypesViewModel>
    {
        private readonly IDomainRepository<AccomplishmentType> _accomplishmentTypeRepository;

        public Handler(IDomainRepository<AccomplishmentType> accomplishmentTypeRepository)
        {
            _accomplishmentTypeRepository = accomplishmentTypeRepository;
        }

        protected override async Task<AccomplishmentTypesViewModel> Handle(GetAccomplishmentTypesQuery query)
        {
            return new AccomplishmentTypesViewModel(await _accomplishmentTypeRepository.GetAll());
        }
    }
}
