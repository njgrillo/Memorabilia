namespace Memorabilia.Application.Features.Dashboard;

public class DashboardChartModel
{
    public double[] Data { get; set; }

    public string[] Labels { get; set; }

    public DashboardChartModel(double[] data, string[] labels)
    {
        Data = data;
        Labels = labels;    
    }
}
