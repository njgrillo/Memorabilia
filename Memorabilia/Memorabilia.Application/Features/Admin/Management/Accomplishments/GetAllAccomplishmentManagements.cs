namespace Memorabilia.Application.Features.Admin.Management.Accomplishments;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetAllAccomplishmentManagements() : IQuery<AccomplishmentManagementModel[]>
{
    public class Handler(IAccomplishmentDetailRepository accomplishmentDetailRepository,                        
                         IPersonAccomplishmentRepository personAccomplishmentRepository,
                          SingleOccurranceAccomplishmentService singleOccurranceAccomplishmentService,
                         YearRangeAccomplishmentService yearRangeAccomplishmentService) 
        : QueryHandler<GetAllAccomplishmentManagements, AccomplishmentManagementModel[]>
    {
        protected override async Task<AccomplishmentManagementModel[]> Handle(GetAllAccomplishmentManagements query)
        {
            List<AccomplishmentManagementModel> accomplishmentManagements = [];

            Entity.AccomplishmentDetail[] accomplishmentDetails = await accomplishmentDetailRepository.GetAll();
            Entity.PersonAccomplishment[] personAccomplishments = (await personAccomplishmentRepository.GetAll()).ToArray();

            accomplishmentManagements.AddRange(AddDateAndYearAccomplishments(accomplishmentDetails, personAccomplishments));
            accomplishmentManagements.AddRange(AddYearRangeAccomplishments(accomplishmentDetails, personAccomplishments));            

            return accomplishmentManagements.ToArray();
        }

        private List<AccomplishmentManagementModel> AddDateAndYearAccomplishments(
            Entity.AccomplishmentDetail[] accomplishmentDetails,
            Entity.PersonAccomplishment[] personAccomplishments)
        {
            List<AccomplishmentManagementModel> accomplishmentManagements = [];

            Constant.AccomplishmentType[] accomplishments 
                = Constant.AccomplishmentType.DateAccomplishment.Concat(Constant.AccomplishmentType.YearAccomplishment).ToArray();

            foreach (Constant.AccomplishmentType accomplishmentType in accomplishments)
            {
                Entity.AccomplishmentDetail accomplishmentDetail
                    = accomplishmentDetails.SingleOrDefault(accomplishmentDetail => accomplishmentDetail.AccomplishmentTypeId == accomplishmentType.Id);

                accomplishmentDetail ??= new Entity.AccomplishmentDetail(accomplishmentType.Id);

                AccomplishmentManagementModel accomplishmentManagement = new(accomplishmentDetail);

                if (!accomplishmentDetail.IgnoreManagement)
                {
                    bool hasMissingNumberOfOccurrences = singleOccurranceAccomplishmentService.HasMissingNumberOfOccurrences(
                                        accomplishmentDetail,
                                        personAccomplishments.Where(personAccomplishment => personAccomplishment.AccomplishmentTypeId == accomplishmentType.Id).ToArray(),
                                        out int missingNumberOfOccurrences);

                    accomplishmentManagement.HasMissingNumberOfOccurrences = hasMissingNumberOfOccurrences;
                    accomplishmentManagement.MissingNumberOfOccurrences = missingNumberOfOccurrences;
                }                

                accomplishmentManagements.Add(accomplishmentManagement);
            }

            return accomplishmentManagements;
        }

        private List<AccomplishmentManagementModel> AddYearRangeAccomplishments(
            Entity.AccomplishmentDetail[] accomplishmentDetails,
            Entity.PersonAccomplishment[] personAccomplishments
            )
        {
            List<AccomplishmentManagementModel> accomplishmentManagements = [];

            foreach (Constant.AccomplishmentType accomplishmentType in Constant.AccomplishmentType.YearRangeAccomplishment)
            {
                Entity.AccomplishmentDetail accomplishmentDetail
                    = accomplishmentDetails.SingleOrDefault(accomplishmentDetail => accomplishmentDetail.AccomplishmentTypeId == accomplishmentType.Id);

                accomplishmentDetail ??= new Entity.AccomplishmentDetail(accomplishmentType.Id);

                AccomplishmentManagementModel accomplishmentManagement = new(accomplishmentDetail);

                Entity.PersonAccomplishment[] filteredPersonAccomplishments
                    = personAccomplishments.Where(personAccomplishment => personAccomplishment.AccomplishmentTypeId == accomplishmentType.Id)
                                           .ToArray();

                if (!accomplishmentDetail.IgnoreManagement)
                {
                    bool hasMissingYears = yearRangeAccomplishmentService.HasMissingYears(
                        accomplishmentDetail,
                        filteredPersonAccomplishments,
                        out int[] missingYears);

                    accomplishmentManagement.HasMissingYears = hasMissingYears;
                    accomplishmentManagement.MissingYears = missingYears;

                    bool hasMissingNumberOfOccurrences = singleOccurranceAccomplishmentService.HasMissingNumberOfOccurrences(
                        accomplishmentDetail,
                        filteredPersonAccomplishments,
                        out int missingNumberOfOccurrences);

                    accomplishmentManagement.HasMissingNumberOfOccurrences = hasMissingNumberOfOccurrences;
                    accomplishmentManagement.MissingNumberOfOccurrences = missingNumberOfOccurrences;
                }

                accomplishmentManagements.Add(accomplishmentManagement);
            }

            return accomplishmentManagements;
        }
    }
}
