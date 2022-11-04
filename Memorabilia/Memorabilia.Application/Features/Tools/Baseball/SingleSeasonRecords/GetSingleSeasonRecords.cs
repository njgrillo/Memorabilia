namespace Memorabilia.Application.Features.Tools.Baseball.SingleSeasonRecords;

public record GetSingleSeasonRecords(int SportId) : IQuery<SingleSeasonRecordsViewModel>
{
    public class Handler : QueryHandler<GetSingleSeasonRecords, SingleSeasonRecordsViewModel>
    {
        private readonly ISingleSeasonRecordRepository _singleSeasonRecordRepository;

        public Handler(ISingleSeasonRecordRepository singleSeasonRecordRepository)
        {
            _singleSeasonRecordRepository = singleSeasonRecordRepository;
        }

        protected override async Task<SingleSeasonRecordsViewModel> Handle(GetSingleSeasonRecords query)
        {
            return new SingleSeasonRecordsViewModel(await _singleSeasonRecordRepository.GetAll(query.SportId));
        }
    }
}
