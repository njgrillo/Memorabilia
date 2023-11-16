namespace Memorabilia.Application.Features.Tools.Shared.Accomplishments;

public record GetAccomplishments(Constant.AccomplishmentType AccomplishmentType, 
                                 Constant.Sport Sport) 
    : IQuery<Entity.PersonAccomplishment[]>
{
    public class Handler(IPersonAccomplishmentRepository personAccomplishmentRepository) 
        : QueryHandler<GetAccomplishments, Entity.PersonAccomplishment[]>
    {
        protected override async Task<Entity.PersonAccomplishment[]> Handle(GetAccomplishments query)
            => (await personAccomplishmentRepository.GetAll(query.AccomplishmentType.Id))
                    .ToArray();            
    }
}
