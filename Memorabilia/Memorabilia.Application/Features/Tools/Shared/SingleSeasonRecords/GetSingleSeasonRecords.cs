using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Tools.Shared.SingleSeasonRecords;

public record GetSingleSeasonRecords(Sport Sport) : IQuery<SingleSeasonRecordsModel>
{
    public class Handler : QueryHandler<GetSingleSeasonRecords, SingleSeasonRecordsModel>
    {
        private readonly ISingleSeasonRecordRepository _singleSeasonRecordRepository;

        public Handler(ISingleSeasonRecordRepository singleSeasonRecordRepository)
        {
            _singleSeasonRecordRepository = singleSeasonRecordRepository;
        }

        protected override async Task<SingleSeasonRecordsModel> Handle(GetSingleSeasonRecords query)
        {
            return new SingleSeasonRecordsModel(await _singleSeasonRecordRepository.GetAll(query.Sport.Id), query.Sport);
        }
    }
}
