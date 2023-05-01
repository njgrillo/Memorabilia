namespace Memorabilia.Application.Features.Services.Dashboard;

public class DashboardItemFactory : IDashboardItemFactory
{
    private readonly List<IDashboardItemRule> _rules = new ();

    public DashboardItemFactory()
    {       
        _rules.Add(new CostBarChartRule());
        _rules.Add(new CostChartRule());
        _rules.Add(new EstimatedValueBarChartRule());
        _rules.Add(new EstimatedValuePieChartRule());
        _rules.Add(new FranchiseChartRule());
        _rules.Add(new ItemTypeChartRule());
        _rules.Add(new SportLeagueLevelChartRule());
    }

    public List<IDashboardItemRule> Rules => _rules;
}
