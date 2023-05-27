namespace Memorabilia.Blazor.Pages.Project.ProjectTypeComponents;

public partial class HallOfFameSelector
{
    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public int? ItemTypeId { get; set; }

    [Parameter]
    public EventCallback<Dictionary<string, object>> ProjectDetailsSet { get; set; }

    [Parameter]
    public int SportLeagueLevelId { get; set; }

    [Parameter]
    public int? Year { get; set; }

    protected ItemType ItemType { get; set; }    

    protected override void OnInitialized()
    {
        if (!ItemTypeId.HasValue)
            return;

        ItemType = ItemType.Find(ItemTypeId.Value);
    }

    protected async Task ItemTypeChanged(ItemType itemType)
    {
        ItemType = itemType;

        await OnParameterChanged();
    }

    protected async Task SportLeagueLevelChanged(int sportLeagueLevelId)
    {
        SportLeagueLevelId = sportLeagueLevelId;

        await OnParameterChanged();
    }

    protected async Task YearChanged(int? year)
    {
        Year = year;

        await OnParameterChanged();
    }

    private async Task OnParameterChanged()
    {
        var parameters = new Dictionary<string, object>
        {
            { "SportLeagueLevelId", SportLeagueLevelId },
        };

        if (ItemType != null)
            parameters.Add("ItemTypeId", ItemType.Id);

        if (Year.HasValue)
            parameters.Add("Year", Year);

        await ProjectDetailsSet.InvokeAsync(parameters);
    }
}
