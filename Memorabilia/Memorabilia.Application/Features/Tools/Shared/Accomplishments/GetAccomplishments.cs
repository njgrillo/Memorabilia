namespace Memorabilia.Application.Features.Tools.Shared.Accomplishments;

public record GetAccomplishments(int AccomplishmentTypeId, Domain.Constants.SportLeagueLevel SportLeagueLevel) : IQuery<AccomplishmentsViewModel>
{
    public class Handler : QueryHandler<GetAccomplishments, AccomplishmentsViewModel>
    {
        private readonly IPersonAccomplishmentRepository _personAccomplishmentRepository;

        public Handler(IPersonAccomplishmentRepository personAccomplishmentRepository)
        {
            _personAccomplishmentRepository = personAccomplishmentRepository;
        }

        protected override async Task<AccomplishmentsViewModel> Handle(GetAccomplishments query)
        {
            return new AccomplishmentsViewModel(await _personAccomplishmentRepository.GetAll(query.AccomplishmentTypeId), query.SportLeagueLevel)
            {
                AccomplishmentTypeId = query.AccomplishmentTypeId
            };
        }
    }
}
