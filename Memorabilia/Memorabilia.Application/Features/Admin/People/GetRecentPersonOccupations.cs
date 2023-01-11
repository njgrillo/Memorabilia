namespace Memorabilia.Application.Features.Admin.People;

public record GetRecentPersonOccupations() : IQuery<RecentPersonOccupationsViewModel[]>
{
    public class Handler : QueryHandler<GetRecentPersonOccupations, RecentPersonOccupationsViewModel[]>
    {
        private readonly IPersonRepository _personRepository;

        public Handler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        protected override async Task<RecentPersonOccupationsViewModel[]> Handle(GetRecentPersonOccupations query)
        {
            var people = await _personRepository.GetMostRecent();

            return people.Select(person => new RecentPersonOccupationsViewModel(person))
                         .ToArray();
        }
    }
}
