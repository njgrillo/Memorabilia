namespace Memorabilia.Application.Features.Tools.Shared.Accomplishments;

public record GetAccomplishments(Constant.AccomplishmentType AccomplishmentType, 
                                 Constant.Sport Sport) 
    : IQuery<Entity.PersonAccomplishment[]>
{
    public class Handler : QueryHandler<GetAccomplishments, Entity.PersonAccomplishment[]>
    {
        private readonly IPersonAccomplishmentRepository _personAccomplishmentRepository;

        public Handler(IPersonAccomplishmentRepository personAccomplishmentRepository)
        {
            _personAccomplishmentRepository = personAccomplishmentRepository;
        }

        protected override async Task<Entity.PersonAccomplishment[]> Handle(GetAccomplishments query)
            => (await _personAccomplishmentRepository.GetAll(query.AccomplishmentType.Id))
                    .ToArray();            
    }
}
