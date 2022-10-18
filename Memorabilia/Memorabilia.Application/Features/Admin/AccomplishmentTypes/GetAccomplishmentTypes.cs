using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.AccomplishmentTypes;

public record GetAccomplishmentTypes() : IQuery<AccomplishmentTypesViewModel>
{
    public class Handler : QueryHandler<GetAccomplishmentTypes, AccomplishmentTypesViewModel>
    {
        private readonly IDomainRepository<AccomplishmentType> _accomplishmentTypeRepository;

        public Handler(IDomainRepository<AccomplishmentType> accomplishmentTypeRepository)
        {
            _accomplishmentTypeRepository = accomplishmentTypeRepository;
        }

        protected override async Task<AccomplishmentTypesViewModel> Handle(GetAccomplishmentTypes query)
        {
            return new AccomplishmentTypesViewModel(await _accomplishmentTypeRepository.GetAll());
        }
    }
}
