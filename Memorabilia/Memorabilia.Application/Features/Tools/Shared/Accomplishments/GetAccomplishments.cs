namespace Memorabilia.Application.Features.Tools.Shared.Accomplishments;

public record GetAccomplishments(Constant.AccomplishmentType AccomplishmentType, Constant.Sport Sport) 
    : IQuery<AccomplishmentsModel>
{
    public class Handler : QueryHandler<GetAccomplishments, AccomplishmentsModel>
    {
        private readonly IPersonAccomplishmentRepository _personAccomplishmentRepository;

        public Handler(IPersonAccomplishmentRepository personAccomplishmentRepository)
        {
            _personAccomplishmentRepository = personAccomplishmentRepository;
        }

        protected override async Task<AccomplishmentsModel> Handle(GetAccomplishments query)
        {
            return new AccomplishmentsModel(await _personAccomplishmentRepository.GetAll(query.AccomplishmentType.Id), query.Sport)
            {
                AccomplishmentType = query.AccomplishmentType
            };
        }
    }
}
