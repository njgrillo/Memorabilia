using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Tools.Shared.CareerRecords;

public record GetCareerRecords(Sport Sport) : IQuery<CareerRecordsModel>
{
    public class Handler : QueryHandler<GetCareerRecords, CareerRecordsModel>
    {
        private readonly ICareerRecordRepository _careerRecordRepository;

        public Handler(ICareerRecordRepository careerRecordRepository)
        {
            _careerRecordRepository = careerRecordRepository;
        }

        protected override async Task<CareerRecordsModel> Handle(GetCareerRecords query)
        {
            return new CareerRecordsModel(await _careerRecordRepository.GetAll(query.Sport.Id), query.Sport);
        }
    }
}
