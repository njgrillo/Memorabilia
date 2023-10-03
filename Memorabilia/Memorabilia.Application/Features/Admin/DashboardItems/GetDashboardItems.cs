﻿namespace Memorabilia.Application.Features.Admin.DashboardItems;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetDashboardItems() : IQuery<Entity.DashboardItem[]>
{
    public class Handler : QueryHandler<GetDashboardItems, Entity.DashboardItem[]>
    {
        private readonly IDomainRepository<Entity.DashboardItem> _dashboardItemRepository;

        public Handler(IDomainRepository<Entity.DashboardItem> dashboardItemRepository)
        {
            _dashboardItemRepository = dashboardItemRepository;
        }

        protected override async Task<Entity.DashboardItem[]> Handle(GetDashboardItems query)
            => await _dashboardItemRepository.GetAll();
    }
}
