namespace Memorabilia.Blazor.Controls.RadioFields;

public partial class RadioField<TItemType>
{
    [Parameter]
    public TItemType EmptyValue { get; set; }

    [Parameter]
    public TItemType[] Options { get; set; }

    [Parameter]
    public TItemType SelectedOption { get; set; }

    [Parameter]
    public EventCallback<TItemType> SelectionChanged { get; set; }

    protected string[] CheckboxNames 
        => Options.Select(option => option.ToString())
                  .ToArray();

    public virtual async Task CheckChanged(string itemName, ChangeEventArgs args)
    {
        var isChecked = (bool)args.Value;
        TItemType item = Options.FirstOrDefault(option => option.ToString() == itemName);

        SelectedOption = isChecked 
            ? item 
            : EmptyValue;

        await SelectionChanged.InvokeAsync(SelectedOption);
    }

    public virtual string SelectedOptionCheckedValue(TItemType item)
        => item?.ToString();

    public virtual string SelectedOptionValue(TItemType item)
        => item?.ToString();
}
