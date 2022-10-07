namespace Memorabilia.Application.Features.Services.Dashboard;

public interface IDashboardItemFactory 
{
    List<IDashboardItemRule> Rules { get; }
}
