namespace Memorabilia.Application.Features.Admin.AccomplishmentTypes;

public record GetAccomplishmentTypes() : IQuery<AccomplishmentTypesModel>
{
    public class Handler : QueryHandler<GetAccomplishmentTypes, AccomplishmentTypesModel>
    {
        private readonly IDomainRepository<Entity.AccomplishmentType> _accomplishmentTypeRepository;

        public Handler(IDomainRepository<Entity.AccomplishmentType> accomplishmentTypeRepository)
        {
            _accomplishmentTypeRepository = accomplishmentTypeRepository;
        }

        protected override async Task<AccomplishmentTypesModel> Handle(GetAccomplishmentTypes query)
        {
            return new AccomplishmentTypesModel(await _accomplishmentTypeRepository.GetAll());
        }
    }
}
