namespace Memorabilia.Blazor.Controls.TypeAhead;

public abstract partial class Autocomplete<TItem> 
    : CommandQuery where TItem : class, IWithName
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Parameter]
    public Color AdornmentColor { get; set; } 
        = Color.Primary;

    [Parameter]
    public string AdornmentIcon { get; set; } 
        = Icons.Material.Filled.Search;

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public bool DisplaySkeleton { get; set; }

    [Parameter]
    public string HelperText { get; set; }

    [Parameter]
    public string Label { get; set; }    

    [Parameter]
    public string Placeholder { get; set; }

    [Parameter]
    public bool ResetValueOnEmptyText { get; set; } 
        = false;

    [Parameter]
    public TItem SelectedValue { get; set; }

    [Parameter]
    public EventCallback<TItem> SelectionChanged { get; set; }

    [Parameter]
    public Variant Variant { get; set; } 
        = Variant.Outlined;

    protected abstract string GetItemSelectedText(TItem item);

    protected abstract string GetItemText(TItem item);

    public abstract Task<IEnumerable<TItem>> Search(string searchText);

    public virtual string GetDisplayText(TItem item)
        => item?.Name;

    protected string Theme { get; set; }

    protected override void OnInitialized()
    {
        AdornmentColor = ApplicationStateService.IsDarkMode
            ? Color.Dark
            : Color.Default;

        Theme = ApplicationStateService.IsDarkMode
            ? "color:white;"
            : string.Empty;

        Variant = ApplicationStateService.IsDarkMode
            ? Variant.Filled
            : Variant.Outlined;
    }
}
