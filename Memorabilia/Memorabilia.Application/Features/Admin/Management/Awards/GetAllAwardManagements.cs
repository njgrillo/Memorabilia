namespace Memorabilia.Application.Features.Admin.Management.Awards;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetAllAwardManagements() : IQuery<AwardManagementModel[]>
{
    public class Handler(IAwardDetailRepository awardDetailRepository,
                         AwardManagementService awardManagementService,
                         IPersonAwardRepository personAwardRepository) 
        : QueryHandler<GetAllAwardManagements, AwardManagementModel[]>
    {
        protected override async Task<AwardManagementModel[]> Handle(GetAllAwardManagements query)
        {
            Entity.PersonAward[] personAwards = (await personAwardRepository.GetAll()).ToArray();

            List<AwardManagementModel> awardManagements = [];

            Entity.AwardDetail[] awardDetails = await awardDetailRepository.GetAll();

            foreach (Constant.AwardType awardType in Constant.AwardType.All)
            {
                Entity.AwardDetail awardDetail = awardDetails.SingleOrDefault(awardDetail => awardDetail.AwardTypeId == awardType.Id);

                awardDetail ??= new Entity.AwardDetail(awardType.Id);

                AwardManagementModel awardManagement = new(awardDetail);

                if (awardDetail.BeginYear > 0)
                {
                    awardManagementService.Analyze(awardDetail, personAwards.Where(personAward => personAward.AwardTypeId == awardType.Id).ToArray());

                    awardManagement.MissingYears = awardManagementService.MissingYears();
                    awardManagement.NumberOfWinnersDoesntMatch = awardManagementService.NumberOfWinnersDoesntMatch();
                }                

                awardManagements.Add(awardManagement);
            }

            return awardManagements.ToArray();
        }
    }
}
