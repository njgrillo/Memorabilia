using Memorabilia.Application.Services.Admin.Management.Accomplishments;

namespace Memorabilia.Application.Features.Admin.Management.Accomplishments;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetAllAccomplishmentManagements() : IQuery<AccomplishmentManagementModel[]>
{
    public class Handler(IAccomplishmentDetailRepository accomplishmentDetailRepository,
                         AccomplishmentManagementService accomplishmentManagementService,
                         IPersonAccomplishmentRepository personAccomplishmentRepository) 
        : QueryHandler<GetAllAccomplishmentManagements, AccomplishmentManagementModel[]>
    {
        protected override async Task<AccomplishmentManagementModel[]> Handle(GetAllAccomplishmentManagements query)
        {
            Entity.PersonAccomplishment[] personAccomplishments = (await personAccomplishmentRepository.GetAll()).ToArray();

            List<AccomplishmentManagementModel> accomplishmentManagements = [];

            Entity.AccomplishmentDetail[] accomplishmentDetails = await accomplishmentDetailRepository.GetAll();

            List<AccomplishmentManagementModel> accomplishments
                = GetAccomplishment(accomplishmentDetails.Where(accomplishmentDetail => !accomplishmentDetail.BeginYear.HasValue && !accomplishmentDetail.Year.HasValue).ToArray() ?? [],
                                    personAccomplishments);

            accomplishmentManagements.AddRange(accomplishments);

            List<AccomplishmentManagementModel> rangeAccomplishments
                = GetAccomplishmentRange(accomplishmentDetails.Where(accomplishmentDetail => accomplishmentDetail.BeginYear.HasValue).ToArray() ?? [],
                                         personAccomplishments);

            accomplishmentManagements.AddRange(rangeAccomplishments);

            List<AccomplishmentManagementModel> yearAccomplishments
                = GetAccomplishmentYear(accomplishmentDetails.Where(accomplishmentDetail => accomplishmentDetail.Year.HasValue)?.ToArray() ?? [],
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
                    accomplishmentManagementService.AnalyzeRange(accomplishmentDetail,
                                                                  personAccomplishments.Where(personAccomplishment => personAccomplishment.AccomplishmentTypeId == accomplishmentType.Id).ToArray());

                    accomplishmentManagement.MissingYears = accomplishmentManagementService.MissingYears();
                    accomplishmentManagement.NumberOfWinnersDoesntMatch = accomplishmentManagementService.NumberOfWinnersDoesntMatch();
                }

                accomplishmentManagements.Add(accomplishmentManagement);
            }

            return accomplishmentManagements.ToArray();
        }

        private List<AccomplishmentManagementModel> GetAccomplishment(Entity.AccomplishmentDetail[] accomplishmentDetails,
                                                                      Entity.PersonAccomplishment[] personAccomplishments)
        {
            List<AccomplishmentManagementModel> accomplishmentManagements = [];

            foreach (Constant.AccomplishmentType accomplishmentType in Constant.AccomplishmentType.YearAccomplishment)
            {
                Entity.AccomplishmentDetail accomplishmentDetail
                    = accomplishmentDetails.SingleOrDefault(accomplishmentDetail => accomplishmentDetail.AccomplishmentTypeId == accomplishmentDetail.Id);

                accomplishmentDetail ??= new Entity.AccomplishmentDetail(accomplishmentType.Id);

                AccomplishmentManagementModel accomplishmentManagement = new(accomplishmentDetail);

                accomplishmentManagementService.AnalyzeRange(accomplishmentDetail,
                                                             personAccomplishments.Where(personAccomplishment => personAccomplishment.AccomplishmentTypeId == accomplishmentType.Id).ToArray());

                accomplishmentManagement.NumberOfWinnersDoesntMatch = accomplishmentManagementService.NumberOfWinnersDoesntMatch();

                accomplishmentManagements.Add(accomplishmentManagement);
            }

            return accomplishmentManagements;
        }

        private List<AccomplishmentManagementModel> GetAccomplishmentRange(Entity.AccomplishmentDetail[] accomplishmentDetails,
                                                                           Entity.PersonAccomplishment[] personAccomplishments)
        {
            List<AccomplishmentManagementModel> accomplishmentManagements = [];

            foreach (Constant.AccomplishmentType accomplishmentType in Constant.AccomplishmentType.YearAccomplishment)
            {
                Entity.AccomplishmentDetail accomplishmentDetail
                    = accomplishmentDetails.SingleOrDefault(accomplishmentDetail => accomplishmentDetail.AccomplishmentTypeId == accomplishmentDetail.Id);

                accomplishmentDetail ??= new Entity.AccomplishmentDetail(accomplishmentType.Id);

                AccomplishmentManagementModel accomplishmentManagement = new(accomplishmentDetail);

                if (accomplishmentDetail.BeginYear.HasValue)
                {
                    accomplishmentManagementService.AnalyzeRange(accomplishmentDetail,
                                                                 personAccomplishments.Where(personAccomplishment => personAccomplishment.AccomplishmentTypeId == accomplishmentType.Id).ToArray());

                    accomplishmentManagement.MissingYears = accomplishmentManagementService.MissingYears();
                    accomplishmentManagement.NumberOfWinnersDoesntMatch = accomplishmentManagementService.NumberOfWinnersDoesntMatch();
                }

                accomplishmentManagements.Add(accomplishmentManagement);
            }

            return accomplishmentManagements;
        }

        private List<AccomplishmentManagementModel> GetAccomplishmentYear(Entity.AccomplishmentDetail[] accomplishmentDetails,
                                                                          Entity.PersonAccomplishment[] personAccomplishments)
        {
            List<AccomplishmentManagementModel> accomplishmentManagements = [];

            foreach (Constant.AccomplishmentType accomplishmentType in Constant.AccomplishmentType.YearAccomplishment)
            {
                Entity.AccomplishmentDetail accomplishmentDetail
                    = accomplishmentDetails.SingleOrDefault(accomplishmentDetail => accomplishmentDetail.AccomplishmentTypeId == accomplishmentDetail.Id);

                accomplishmentDetail ??= new Entity.AccomplishmentDetail(accomplishmentType.Id);

                AccomplishmentManagementModel accomplishmentManagement = new(accomplishmentDetail);

                accomplishmentManagementService.AnalyzeYear(accomplishmentDetail,
                                                            personAccomplishments.Where(personAccomplishment => personAccomplishment.AccomplishmentTypeId == accomplishmentType.Id && personAccomplishment.Year.HasValue && personAccomplishment.Year.Value == accomplishmentDetail.Year).ToArray());

                accomplishmentManagement.NumberOfWinnersDoesntMatch = accomplishmentManagementService.NumberOfWinnersDoesntMatch();

                accomplishmentManagements.Add(accomplishmentManagement);
            }

            return accomplishmentManagements;
        }
    }
}
