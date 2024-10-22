namespace Memorabilia.Application.Features.Admin.Sports.Management.Accomplishments.Leaders;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetSportLeaders(int SportId, int Year)
    : IQuery<SportLeadersViewModel>
{
    public class Handler(ILeaderRepository leaderRepository)
        : QueryHandler<GetSportLeaders, SportLeadersViewModel>
    {
        protected override async Task<SportLeadersViewModel> Handle(GetSportLeaders query)
        {
            Entity.Leader[] leaders
                = (await leaderRepository.GetAll(query.SportId, query.Year)).ToArray();

            return new SportLeadersViewModel(query.SportId, leaders);
        }
    }
}
