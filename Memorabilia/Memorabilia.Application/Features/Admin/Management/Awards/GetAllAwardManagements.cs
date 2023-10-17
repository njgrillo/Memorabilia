namespace Memorabilia.Application.Features.Admin.Management.Awards;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetAllAwardManagements() : IQuery<AwardManagementModel[]>
{
    public class Handler : QueryHandler<GetAllAwardManagements, AwardManagementModel[]>
    {
        private readonly IAwardDetailRepository _awardDetailRepository;
        private readonly AwardManagementService _awardManagementService;
        private readonly IPersonAwardRepository _personAwardRepository;

        public Handler(IAwardDetailRepository awardDetailRepository,
            AwardManagementService awardManagementService,
            IPersonAwardRepository personAwardRepository)
        {
            _awardDetailRepository = awardDetailRepository;
            _awardManagementService = awardManagementService;
            _personAwardRepository = personAwardRepository;
        }

        protected override async Task<AwardManagementModel[]> Handle(GetAllAwardManagements query)
        {
            Entity.PersonAward[] personAwards = (await _personAwardRepository.GetAll()).ToArray();

            List<AwardManagementModel> awardManagements = new();

            Entity.AwardDetail[] awardDetails = await _awardDetailRepository.GetAll();

            foreach (Constant.AwardType awardType in Constant.AwardType.All)
            {
                Entity.AwardDetail awardDetail = awardDetails.SingleOrDefault(awardDetail => awardDetail.AwardTypeId == awardType.Id);

                awardDetail ??= new Entity.AwardDetail(awardType.Id);

                AwardManagementModel awardManagement = new(awardDetail);

                if (awardDetail.BeginYear > 0)
                {
                    _awardManagementService.Analyze(awardDetail, personAwards.Where(personAward => personAward.AwardTypeId == awardType.Id).ToArray());

                    awardManagement.MissingYears = _awardManagementService.MissingYears();
                    awardManagement.NumberOfWinnersDoesntMatch = _awardManagementService.NumberOfWinnersDoesntMatch();
                }                

                awardManagements.Add(awardManagement);
            }

            return awardManagements.ToArray();
        }
    }
}
