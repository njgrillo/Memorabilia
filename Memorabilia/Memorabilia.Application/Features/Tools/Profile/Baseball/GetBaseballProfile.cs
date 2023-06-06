namespace Memorabilia.Application.Features.Tools.Profile;

public record GetBaseballProfile(int PersonId) : IQuery<BaseballProfileModel>
{
    public class Handler : QueryHandler<GetBaseballProfile, BaseballProfileModel>
    {
        private readonly IPersonRepository _personRepository;

        public Handler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        protected override async Task<BaseballProfileModel> Handle(GetBaseballProfile query)
        {
            return new BaseballProfileModel(await _personRepository.Get(query.PersonId));
        }
    }
}
