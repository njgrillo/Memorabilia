namespace Memorabilia.Application.Features.Dashboard;

public class DashboardChartModel(double[] data, string[] labels)
{
    public double[] Data { get; set; } 
        = data;

    public string[] Labels { get; set; } 
        = labels;
}
