namespace Memorabilia.Application.Features.Admin.Management.AllStars;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetAllAllStarManagements() : IQuery<AllStarManagementModel[]>
{
    public class Handler(IAllStarDetailRepository allStarDetailRepository,
                         AllStarManagementService allStarManagementService,
                         IAllStarRepository allStarRepository) 
        : QueryHandler<GetAllAllStarManagements, AllStarManagementModel[]>
    {
        protected override async Task<AllStarManagementModel[]> Handle(GetAllAllStarManagements query)
        {
            Entity.AllStarDetail[] allStarDetails = await allStarDetailRepository.GetAll();

            List<AllStarManagementModel> allStarManagements = [];

            Entity.AllStar[] allStars = await allStarRepository.GetAll();

            foreach (Entity.AllStarDetail allStarDetail in allStarDetails)
            {
                AllStarManagementModel allStarManagement = new(allStarDetail);

                allStarManagementService.Analyze(allStarDetail, 
                                                  allStars.Where(allStar => allStar.Year == allStarDetail.Year 
                                                                         && allStar.SportId == allStarDetail.SportLeagueLevel.SportId 
                                                                         && (allStar.SportLeagueLevelId == null || allStar.SportLeagueLevelId.Value == allStarDetail.SportLeagueLevelId))
                                                          .ToArray());

                allStarManagement.NumberOfAllStarsDoesntMatch = allStarManagementService.NumberOfAllStarsDoesntMatch();

                allStarManagements.Add(allStarManagement);
            }


            return allStarManagements.ToArray();
        }
    }
}
