using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Tools.Shared.SingleSeasonRecords;

public record GetSingleSeasonRecords(Sport Sport) : IQuery<SingleSeasonRecordsViewModel>
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
            return new SingleSeasonRecordsViewModel(await _singleSeasonRecordRepository.GetAll(query.Sport.Id), query.Sport);
        }
    }
}
