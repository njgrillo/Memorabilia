namespace Memorabilia.Application.Features.Tools.Shared.Awards;

public record GetAwards(Constant.AwardType AwardType, Constant.Sport Sport) 
    : IQuery<Entity.PersonAward[]>
{
    public class Handler : QueryHandler<GetAwards, Entity.PersonAward[]>
    {
        private readonly IPersonAwardRepository _personAwardRepository;

        public Handler(IPersonAwardRepository personAwardRepository)
        {
            _personAwardRepository = personAwardRepository;
        }

        protected override async Task<Entity.PersonAward[]> Handle(GetAwards query)
            => (await _personAwardRepository.GetAll(query.AwardType.Id))
                    .ToArray();
    }
}
