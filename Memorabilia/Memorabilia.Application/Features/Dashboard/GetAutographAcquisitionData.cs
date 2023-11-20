﻿namespace Memorabilia.Application.Features.Dashboard;

public record GetAutographAcquisitionData() : IQuery<DashboardChartModel>
{
    public class Handler(IAutographRepository repository,
                         IApplicationStateService applicationStateService) 
        : QueryHandler<GetAutographAcquisitionData, DashboardChartModel>
    {
        protected override async Task<DashboardChartModel> Handle(GetAutographAcquisitionData query)
        {
            int[] acquisitionTypeIds 
                = repository.GetAcquisitionTypeIds(applicationStateService.CurrentUser.Id);

            string[] acquisitionTypeNames 
                = acquisitionTypeIds.Select(acquisitionTypeId => Constant.AcquisitionType.Find(acquisitionTypeId).Name)
                                    .Distinct()
                                    .ToArray();

            var labels = new List<string>();
            var counts = new List<double>();

            foreach (string acquisitionTypeName in acquisitionTypeNames)
            {
                var acquisitionType = Constant.AcquisitionType.Find(acquisitionTypeName);
                int count = acquisitionTypeIds.Count(acquisitionTypeId => acquisitionTypeId == acquisitionType.Id);

                counts.Add(count);
                labels.Add($"{acquisitionTypeName} ({count})");
            }

            return await Task.FromResult(new DashboardChartModel(counts.ToArray(), labels.ToArray()));
        }
    }
}
