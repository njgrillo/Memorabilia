namespace Memorabilia.Application.Features.Tools.Shared.Awards;

public record GetAwards(Constant.AwardType AwardType, Constant.Sport Sport) : IQuery<AwardsModel>
{
    public class Handler : QueryHandler<GetAwards, AwardsModel>
    {
        private readonly IPersonAwardRepository _personAwardRepository;

        public Handler(IPersonAwardRepository personAwardRepository)
        {
            _personAwardRepository = personAwardRepository;
        }

        protected override async Task<AwardsModel> Handle(GetAwards query)
        {
            return new AwardsModel(await _personAwardRepository.GetAll(query.AwardType.Id), query.Sport)
            {
                AwardType = query.AwardType
            };
        }
    }
}
