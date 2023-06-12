namespace Memorabilia.Application.Features.Tools.Shared.CareerRecords;

public record GetCareerRecords(Constant.Sport Sport) : IQuery<Entity.CareerRecord[]>
{
    public class Handler : QueryHandler<GetCareerRecords, Entity.CareerRecord[]>
    {
        private readonly ICareerRecordRepository _careerRecordRepository;

        public Handler(ICareerRecordRepository careerRecordRepository)
        {
            _careerRecordRepository = careerRecordRepository;
        }

        protected override async Task<Entity.CareerRecord[]> Handle(GetCareerRecords query)
            => (await _careerRecordRepository.GetAll(query.Sport.Id))
                    .ToArray();
    }
}
