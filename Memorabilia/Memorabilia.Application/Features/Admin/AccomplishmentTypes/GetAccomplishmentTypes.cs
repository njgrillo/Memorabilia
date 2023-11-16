namespace Memorabilia.Application.Features.Admin.AccomplishmentTypes;

public record GetAccomplishmentTypes() : IQuery<Entity.AccomplishmentType[]>
{
    public class Handler(IDomainRepository<Entity.AccomplishmentType> accomplishmentTypeRepository) 
        : QueryHandler<GetAccomplishmentTypes, Entity.AccomplishmentType[]>
    {
        protected override async Task<Entity.AccomplishmentType[]> Handle(GetAccomplishmentTypes query)
            => await accomplishmentTypeRepository.GetAll();
    }
}
