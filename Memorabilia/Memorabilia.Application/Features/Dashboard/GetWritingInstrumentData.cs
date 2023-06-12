﻿namespace Memorabilia.Application.Features.Dashboard;

public record GetWritingInstrumentData(int UserId) : IQuery<DashboardChartModel>
{
    public class Handler : QueryHandler<GetWritingInstrumentData, DashboardChartModel>
    {
        private readonly IAutographRepository _repository;

        public Handler(IAutographRepository repository)
        {
            _repository = repository;
        }

        protected override async Task<DashboardChartModel> Handle(GetWritingInstrumentData query)
        {
            int[] writingInstrumentIds = _repository.GetWritingInstrumentIds(query.UserId);
            string[] writingInstrumentNames = writingInstrumentIds.Select(writingInstrumentId => Constant.WritingInstrument.Find(writingInstrumentId).Name)
                                                                  .Distinct()
                                                                  .ToArray();

            var labels = new List<string>();
            var counts = new List<double>();

            foreach (string writingInstrumentName in writingInstrumentNames)
            {
                var writingInstrument = Constant.WritingInstrument.Find(writingInstrumentName);
                var count = writingInstrumentIds.Count(writingInstrumentId => writingInstrumentId == writingInstrument.Id);

                counts.Add(count);
                labels.Add($"{writingInstrumentName} ({count})");
            }

            return await Task.FromResult(new DashboardChartModel(counts.ToArray(), labels.ToArray()));
        }
    }
}
