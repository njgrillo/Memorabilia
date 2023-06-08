namespace Memorabilia.Blazor.Controls.Charts;

public abstract class Chart : ComponentBase
{
    [Parameter]
    public double[] Data { get; set; }

    [Parameter]
    public string Height { get; set; } 
        = "300px";

    [Parameter]
    public string[] Labels { get; set; }

    [Parameter]
    public string Summary { get; set; }

    [Parameter]
    public string Width { get; set; } 
        = "300px";
}
