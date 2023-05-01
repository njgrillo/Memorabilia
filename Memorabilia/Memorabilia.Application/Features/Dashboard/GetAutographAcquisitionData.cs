﻿namespace Memorabilia.Application.Features.Dashboard;

public record GetAutographAcquisitionData(int UserId) : IQuery<DashboardChartViewModel>
{
    public class Handler : QueryHandler<GetAutographAcquisitionData, DashboardChartViewModel>
    {
        private readonly IAutographRepository _repository;

        public Handler(IAutographRepository repository)
        {
            _repository = repository;
        }

        protected override async Task<DashboardChartViewModel> Handle(GetAutographAcquisitionData query)
        {
            var acquisitionTypeIds = _repository.GetAcquisitionTypeIds(query.UserId);
            var acquisitionTypeNames = acquisitionTypeIds.Select(acquisitionTypeId => Domain.Constants.AcquisitionType.Find(acquisitionTypeId).Name)
                                                         .Distinct();

            var labels = new List<string>();
            var counts = new List<double>();

            foreach (var acquisitionTypeName in acquisitionTypeNames)
            {
                var acquisitionType = Domain.Constants.AcquisitionType.Find(acquisitionTypeName);
                var count = acquisitionTypeIds.Count(acquisitionTypeId => acquisitionTypeId == acquisitionType.Id);

                counts.Add(count);
                labels.Add($"{acquisitionTypeName} ({count})");
            }

            return await Task.FromResult(new DashboardChartViewModel(counts.ToArray(), labels.ToArray()));
        }
    }
}
