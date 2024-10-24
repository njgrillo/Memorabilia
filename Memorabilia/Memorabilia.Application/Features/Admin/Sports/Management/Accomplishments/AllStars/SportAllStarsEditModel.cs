namespace Memorabilia.Application.Features.Admin.Sports.Management.Accomplishments.AllStars;

public class SportAllStarsEditModel : EditModel
{
    public SportAllStarsEditModel() { }

    public SportAllStarsEditModel(Entity.AllStar[] allStars)
    {
        AllStars = allStars.Select(allStar => new SportAllStarEditModel(allStar)).ToList();
    }

    public List<SportAllStarEditModel> AllStars { get; set; }
        = [];    
}
