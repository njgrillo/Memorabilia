namespace Memorabilia.Application.Features.Dashboard;

public class DashboardChartViewModel
{
    public double[] Data { get; set; }

    public string[] Labels { get; set; }

    public DashboardChartViewModel(double[] data, string[] labels)
    {
        Data = data;
        Labels = labels;    
    }
}
