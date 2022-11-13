namespace Memorabilia.Application.Features.Tools.Shared.CareerRecords;

public record GetCareerRecords(Domain.Constants.SportLeagueLevel SportLeagueLevel) : IQuery<CareerRecordsViewModel>
{
    public class Handler : QueryHandler<GetCareerRecords, CareerRecordsViewModel>
    {
        private readonly ICareerRecordRepository _careerRecordRepository;

        public Handler(ICareerRecordRepository careerRecordRepository)
        {
            _careerRecordRepository = careerRecordRepository;
        }

        protected override async Task<CareerRecordsViewModel> Handle(GetCareerRecords query)
        {
            return new CareerRecordsViewModel(await _careerRecordRepository.GetAll(query.SportLeagueLevel.Sport.Id), query.SportLeagueLevel);
        }
    }
}
