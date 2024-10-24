namespace Memorabilia.Application.Features.Admin.Sports.Management.Accomplishments.AllStars;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetSportAllStars(int SportId, int? Year = null)
    : IQuery<SportAllStarsViewModel>
{
    public class Handler(IAllStarRepository AllStarRepository)
        : QueryHandler<GetSportAllStars, SportAllStarsViewModel>
    {
        protected override async Task<SportAllStarsViewModel> Handle(GetSportAllStars query)
        {
            Entity.AllStar[] allStars
                = (await AllStarRepository.GetAll(query.SportId, query.Year)).ToArray();

            return new SportAllStarsViewModel(query.SportId, allStars);
        }
    }
}
