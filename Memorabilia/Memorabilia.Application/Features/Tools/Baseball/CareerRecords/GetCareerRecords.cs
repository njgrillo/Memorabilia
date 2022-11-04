namespace Memorabilia.Application.Features.Tools.Baseball.CareerRecords;

public record GetCareerRecords(int SportId) : IQuery<CareerRecordsViewModel>
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
            return new CareerRecordsViewModel(await _careerRecordRepository.GetAll(query.SportId));
        }
    }
}
