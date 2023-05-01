﻿namespace Memorabilia.Application.Features.Dashboard;

public record GetWritingInstrumentData(int UserId) : IQuery<DashboardChartViewModel>
{
    public class Handler : QueryHandler<GetWritingInstrumentData, DashboardChartViewModel>
    {
        private readonly IAutographRepository _repository;

        public Handler(IAutographRepository repository)
        {
            _repository = repository;
        }

        protected override async Task<DashboardChartViewModel> Handle(GetWritingInstrumentData query)
        {
            var writingInstrumentIds = _repository.GetWritingInstrumentIds(query.UserId);
            var writingInstrumentNames = writingInstrumentIds.Select(writingInstrumentId => Domain.Constants.WritingInstrument.Find(writingInstrumentId).Name)
                                                             .Distinct();

            var labels = new List<string>();
            var counts = new List<double>();

            foreach (var writingInstrumentName in writingInstrumentNames)
            {
                var writingInstrument = Domain.Constants.WritingInstrument.Find(writingInstrumentName);
                var count = writingInstrumentIds.Count(writingInstrumentId => writingInstrumentId == writingInstrument.Id);

                counts.Add(count);
                labels.Add($"{writingInstrumentName} ({count})");
            }

            return await Task.FromResult(new DashboardChartViewModel(counts.ToArray(), labels.ToArray()));
        }
    }
}
