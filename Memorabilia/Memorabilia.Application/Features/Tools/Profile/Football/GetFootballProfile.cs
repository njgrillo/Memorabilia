namespace Memorabilia.Application.Features.Tools.Profile.Football;

public record GetFootballProfile(int PersonId): IQuery<FootballProfileModel>
{
    public class Handler : QueryHandler<GetFootballProfile, FootballProfileModel>
    {
        private readonly IPersonRepository _personRepository;

        public Handler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        protected override async Task<FootballProfileModel> Handle(GetFootballProfile query)
        {
            return new FootballProfileModel(await _personRepository.Get(query.PersonId));
        }
    }
}
