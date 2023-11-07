namespace Memorabilia.Blazor.Pages.Help;

public partial class ViewHelp
{
    protected HelpItem SelectedHelpItem { get; set; }

    protected void OnItemSelected(HelpItem helpItem)
    {     
        SelectedHelpItem = helpItem;
    }
}
