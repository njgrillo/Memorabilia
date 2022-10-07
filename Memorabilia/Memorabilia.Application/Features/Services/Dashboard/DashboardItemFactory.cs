namespace Memorabilia.Application.Features.Services.Dashboard;

public class DashboardItemFactory : IDashboardItemFactory
{
    private readonly List<IDashboardItemRule> _rules = new ();

    public DashboardItemFactory()
    {
        _rules.Add(new AutographAcquisitionTypeChartRule());
        _rules.Add(new AutographConditionChartRule());            
        _rules.Add(new BrandChartRule());
        _rules.Add(new ColorChartRule());
        _rules.Add(new CostBarChartRule());
        _rules.Add(new CostChartRule());
        _rules.Add(new EstimatedValueBarChartRule());
        _rules.Add(new EstimatedValuePieChartRule());
        _rules.Add(new FranchiseChartRule());
        _rules.Add(new ItemTypeChartRule());
        _rules.Add(new MemorabiliaAcquisitionTypeChartRule());
        _rules.Add(new MemorabiliaConditionChartRule());
        _rules.Add(new MemorabiliaPurchaseTypeChartRule());
        _rules.Add(new SizeChartRule());
        _rules.Add(new SportLeagueLevelChartRule());
        _rules.Add(new SportChartRule());
        _rules.Add(new SpotChartRule());
        _rules.Add(new WritingInstrumentChartRule());
    }

    public List<IDashboardItemRule> Rules => _rules;
}
