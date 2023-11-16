namespace Memorabilia.Blazor.Pages.Help;

public partial class ViewHelp
{
    protected Type HelpComponent;

    protected Dictionary<string, object> HelpComponentParameters { get; set; }
        = [];

    protected HelpItem SelectedHelpItem { get; set; }

    protected void OnItemSelected(HelpItem helpItem)
    {     
        SelectedHelpItem = helpItem;

        var type = Type.GetType($"Memorabilia.Blazor.Pages.Help.HelpComponents.{SelectedHelpItem}HelpSection");

        if (type == null)
            return;

        HelpComponent = type;
    }
}
