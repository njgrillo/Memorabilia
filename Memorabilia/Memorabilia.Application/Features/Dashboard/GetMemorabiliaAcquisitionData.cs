﻿namespace Memorabilia.Application.Features.Dashboard;

public record GetMemorabiliaAcquisitionData(int UserId) : IQuery<DashboardChartModel>
{
    public class Handler : QueryHandler<GetMemorabiliaAcquisitionData, DashboardChartModel>
    {
        private readonly IMemorabiliaItemRepository _repository;

        public Handler(IMemorabiliaItemRepository repository)
        {
            _repository = repository;
        }

        protected override async Task<DashboardChartModel> Handle(GetMemorabiliaAcquisitionData query)
        {
            int[] acquisitionTypeIds = _repository.GetAcquisitionTypeIds(query.UserId);
            string[] acquisitionTypeNames = acquisitionTypeIds.Select(acquisitionTypeId => Constant.AcquisitionType.Find(acquisitionTypeId).Name)
                                                              .Distinct()
                                                              .ToArray();

            var labels = new List<string>();
            var counts = new List<double>();

            foreach (string acquisitionTypeName in acquisitionTypeNames)
            {
                var acquisitionType = Constant.AcquisitionType.Find(acquisitionTypeName);
                var count = acquisitionTypeIds.Count(acquisitionTypeId => acquisitionTypeId == acquisitionType.Id);

                counts.Add(count);
                labels.Add($"{acquisitionTypeName} ({count})");
            }

            return await Task.FromResult(new DashboardChartModel(counts.ToArray(), labels.ToArray()));
        }
    }
}
