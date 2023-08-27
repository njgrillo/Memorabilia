namespace Memorabilia.Application.Features.Admin.Management.Accomplishments;

public record GetAllAccomplishmentManagements() : IQuery<AccomplishmentManagementModel[]>
{
    public class Handler : QueryHandler<GetAllAccomplishmentManagements, AccomplishmentManagementModel[]>
    {
        private readonly IAccomplishmentDetailRepository _accomplishmentDetailRepository;
        private readonly AccomplishmentManagementService _accomplishmentManagementService;
        private readonly IPersonAccomplishmentRepository _personAccomplishmentRepository;

        public Handler(IAccomplishmentDetailRepository accomplishmentDetailRepository,
            AccomplishmentManagementService accomplishmentManagementService,
            IPersonAccomplishmentRepository personAccomplishmentRepository)
        {
            _accomplishmentDetailRepository = accomplishmentDetailRepository;
            _accomplishmentManagementService = accomplishmentManagementService;
            _personAccomplishmentRepository = personAccomplishmentRepository;
        }

        protected override async Task<AccomplishmentManagementModel[]> Handle(GetAllAccomplishmentManagements query)
        {
            Entity.PersonAccomplishment[] personAccomplishments = (await _personAccomplishmentRepository.GetAll()).ToArray();

            List<AccomplishmentManagementModel> accomplishmentManagements = new();

            Entity.AccomplishmentDetail[] accomplishmentDetails = await _accomplishmentDetailRepository.GetAll();

            List<AccomplishmentManagementModel> accomplishments
                = GetAccomplishment(accomplishmentDetails.Where(accomplishmentDetail => !accomplishmentDetail.BeginYear.HasValue && !accomplishmentDetail.Year.HasValue).ToArray() ?? Array.Empty<Entity.AccomplishmentDetail>(),
                                    personAccomplishments);

            accomplishmentManagements.AddRange(accomplishments);

            List<AccomplishmentManagementModel> rangeAccomplishments
                = GetAccomplishmentRange(accomplishmentDetails.Where(accomplishmentDetail => accomplishmentDetail.BeginYear.HasValue).ToArray() ?? Array.Empty<Entity.AccomplishmentDetail>(),
                                         personAccomplishments);

            accomplishmentManagements.AddRange(rangeAccomplishments);

            List<AccomplishmentManagementModel> yearAccomplishments
                = GetAccomplishmentYear(accomplishmentDetails.Where(accomplishmentDetail => accomplishmentDetail.Year.HasValue)?.ToArray() ?? Array.Empty<Entity.AccomplishmentDetail>(),
                                        personAccomplishments);

            accomplishmentManagements.AddRange(yearAccomplishments);

            foreach (Constant.AccomplishmentType accomplishmentType in Constant.AccomplishmentType.YearAccomplishment)
            {
                Entity.AccomplishmentDetail accomplishmentDetail
                    = accomplishmentDetails.SingleOrDefault(accomplishmentDetail => accomplishmentDetail.AccomplishmentTypeId == accomplishmentDetail.Id);

                accomplishmentDetail ??= new Entity.AccomplishmentDetail(accomplishmentType.Id);

                AccomplishmentManagementModel accomplishmentManagement = new(accomplishmentDetail);

                if (accomplishmentDetail.BeginYear.HasValue)
                {
                    _accomplishmentManagementService.AnalyzeRange(accomplishmentDetail,
                                                                  personAccomplishments.Where(personAccomplishment => personAccomplishment.AccomplishmentTypeId == accomplishmentType.Id).ToArray());

                    accomplishmentManagement.MissingYears = _accomplishmentManagementService.MissingYears();
                    accomplishmentManagement.NumberOfWinnersDoesntMatch = _accomplishmentManagementService.NumberOfWinnersDoesntMatch();
                }

                accomplishmentManagements.Add(accomplishmentManagement);
            }

            return accomplishmentManagements.ToArray();
        }

        private List<AccomplishmentManagementModel> GetAccomplishment(Entity.AccomplishmentDetail[] accomplishmentDetails,
                                                                      Entity.PersonAccomplishment[] personAccomplishments)
        {
            List<AccomplishmentManagementModel> accomplishmentManagements = new();

            foreach (Constant.AccomplishmentType accomplishmentType in Constant.AccomplishmentType.YearAccomplishment)
            {
                Entity.AccomplishmentDetail accomplishmentDetail
                    = accomplishmentDetails.SingleOrDefault(accomplishmentDetail => accomplishmentDetail.AccomplishmentTypeId == accomplishmentDetail.Id);

                accomplishmentDetail ??= new Entity.AccomplishmentDetail(accomplishmentType.Id);

                AccomplishmentManagementModel accomplishmentManagement = new(accomplishmentDetail);

                _accomplishmentManagementService.AnalyzeRange(accomplishmentDetail,
                                                              personAccomplishments.Where(personAccomplishment => personAccomplishment.AccomplishmentTypeId == accomplishmentType.Id).ToArray());

                accomplishmentManagement.NumberOfWinnersDoesntMatch = _accomplishmentManagementService.NumberOfWinnersDoesntMatch();

                accomplishmentManagements.Add(accomplishmentManagement);
            }

            return accomplishmentManagements;
        }

        private List<AccomplishmentManagementModel> GetAccomplishmentRange(Entity.AccomplishmentDetail[] accomplishmentDetails,
                                                                           Entity.PersonAccomplishment[] personAccomplishments)
        {
            List<AccomplishmentManagementModel> accomplishmentManagements = new();

            foreach (Constant.AccomplishmentType accomplishmentType in Constant.AccomplishmentType.YearAccomplishment)
            {
                Entity.AccomplishmentDetail accomplishmentDetail
                    = accomplishmentDetails.SingleOrDefault(accomplishmentDetail => accomplishmentDetail.AccomplishmentTypeId == accomplishmentDetail.Id);

                accomplishmentDetail ??= new Entity.AccomplishmentDetail(accomplishmentType.Id);

                AccomplishmentManagementModel accomplishmentManagement = new(accomplishmentDetail);

                if (accomplishmentDetail.BeginYear.HasValue)
                {
                    _accomplishmentManagementService.AnalyzeRange(accomplishmentDetail,
                                                                  personAccomplishments.Where(personAccomplishment => personAccomplishment.AccomplishmentTypeId == accomplishmentType.Id).ToArray());

                    accomplishmentManagement.MissingYears = _accomplishmentManagementService.MissingYears();
                    accomplishmentManagement.NumberOfWinnersDoesntMatch = _accomplishmentManagementService.NumberOfWinnersDoesntMatch();
                }

                accomplishmentManagements.Add(accomplishmentManagement);
            }

            return accomplishmentManagements;
        }

        private List<AccomplishmentManagementModel> GetAccomplishmentYear(Entity.AccomplishmentDetail[] accomplishmentDetails,
                                                                          Entity.PersonAccomplishment[] personAccomplishments)
        {
            List<AccomplishmentManagementModel> accomplishmentManagements = new();

            foreach (Constant.AccomplishmentType accomplishmentType in Constant.AccomplishmentType.YearAccomplishment)
            {
                Entity.AccomplishmentDetail accomplishmentDetail
                    = accomplishmentDetails.SingleOrDefault(accomplishmentDetail => accomplishmentDetail.AccomplishmentTypeId == accomplishmentDetail.Id);

                accomplishmentDetail ??= new Entity.AccomplishmentDetail(accomplishmentType.Id);

                AccomplishmentManagementModel accomplishmentManagement = new(accomplishmentDetail);

                _accomplishmentManagementService.AnalyzeYear(accomplishmentDetail,
                                                             personAccomplishments.Where(personAccomplishment => personAccomplishment.AccomplishmentTypeId == accomplishmentType.Id && personAccomplishment.Year.HasValue && personAccomplishment.Year.Value == accomplishmentDetail.Year).ToArray());

                accomplishmentManagement.NumberOfWinnersDoesntMatch = _accomplishmentManagementService.NumberOfWinnersDoesntMatch();

                accomplishmentManagements.Add(accomplishmentManagement);
            }

            return accomplishmentManagements;
        }
    }
}
