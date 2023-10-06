namespace Memorabilia.Application.Features.Admin.Management.AllStars;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetAllAllStarManagements() : IQuery<AllStarManagementModel[]>
{
    public class Handler : QueryHandler<GetAllAllStarManagements, AllStarManagementModel[]>
    {
        private readonly IAllStarDetailRepository _allStarDetailRepository;
        private readonly AllStarManagementService _allStarManagementService;
        private readonly IAllStarRepository _allStarRepository;

        public Handler(IAllStarDetailRepository allStarDetailRepository,
            AllStarManagementService allStarManagementService,
            IAllStarRepository allStarRepository)
        {
            _allStarDetailRepository = allStarDetailRepository;
            _allStarManagementService = allStarManagementService;
            _allStarRepository = allStarRepository;
        }

        protected override async Task<AllStarManagementModel[]> Handle(GetAllAllStarManagements query)
        {
            Entity.AllStarDetail[] allStarDetails = await _allStarDetailRepository.GetAll();

            List<AllStarManagementModel> allStarManagements = new();

            Entity.AllStar[] allStars = await _allStarRepository.GetAll();

            foreach (Entity.AllStarDetail allStarDetail in allStarDetails)
            {
                AllStarManagementModel allStarManagement = new(allStarDetail);

                _allStarManagementService.Analyze(allStarDetail, 
                                                  allStars.Where(allStar => allStar.Year == allStarDetail.Year 
                                                                         && allStar.SportId == allStarDetail.SportLeagueLevel.SportId 
                                                                         && (allStar.SportLeagueLevelId == null || allStar.SportLeagueLevelId.Value == allStarDetail.SportLeagueLevelId))
                                                          .ToArray());

                allStarManagement.NumberOfAllStarsDoesntMatch = _allStarManagementService.NumberOfAllStarsDoesntMatch();

                allStarManagements.Add(allStarManagement);
            }


            return allStarManagements.ToArray();
        }
    }
}
