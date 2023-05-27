namespace Memorabilia.Blazor.Pages.Project.ProjectTypeComponents;

public partial class HelmetTypeSelector
{
    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public int HelmetFinishId { get; set; }

    [Parameter]
    public int HelmetTypeId { get; set; }

    [Parameter]
    public EventCallback<Dictionary<string, object>> ProjectDetailsSet { get; set; }

    [Parameter]
    public int? SizeId { get; set; }

    protected Domain.Constants.Size Size { get; set; }

    protected override void OnInitialized()
    {
        if (!SizeId.HasValue)
            return;

        Size = Domain.Constants.Size.Find(SizeId.Value);
    }

    protected async Task HelmetFinishChanged(int helmetFinishId)
    {
        HelmetFinishId = helmetFinishId;

        await OnParameterChanged();
    }

    protected async Task HelmetTypeChanged(int helmetTypeId)
    {
        HelmetTypeId = helmetTypeId;

        await OnParameterChanged();
    }

    protected async Task SizeChanged(Domain.Constants.Size size)
    {
        Size = size;

        await OnParameterChanged();
    }

    private async Task OnParameterChanged()
    {
        var parameters = new Dictionary<string, object>
        {
            { "HelmetTypeId", HelmetTypeId },
        };

        if (HelmetFinishId > 0)
            parameters.Add("HelmetFinishId", HelmetFinishId);

        if (Size != null)
            parameters.Add("SizeId", Size.Id);

        await ProjectDetailsSet.InvokeAsync(parameters);
    }
}
