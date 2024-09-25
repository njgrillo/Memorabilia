namespace Memorabilia.Application.Features.Admin.People.Management.Accomplishments.Records;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetSportRecords(int SportId)
    : IQuery<SportRecordsViewModel>
{
    public class Handler(ICareerRecordRepository careerRecordRepository, ISingleSeasonRecordRepository singleSeasonRecordRepository)
        : QueryHandler<GetSportRecords, SportRecordsViewModel>
    {
        protected override async Task<SportRecordsViewModel> Handle(GetSportRecords query)
        {
            Entity.CareerRecord[] careerRecords
                = (await careerRecordRepository.GetAll(query.SportId)).ToArray();

            Entity.SingleSeasonRecord[] singleSeasonRecords
                = (await singleSeasonRecordRepository.GetAll(query.SportId)).ToArray();

            return new SportRecordsViewModel(query.SportId, careerRecords, singleSeasonRecords);
        }
    }
}
