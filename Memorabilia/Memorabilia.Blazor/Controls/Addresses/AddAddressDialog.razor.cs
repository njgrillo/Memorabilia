namespace Memorabilia.Blazor.Controls.Addresses;

public partial class AddAddressDialog
{
    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    protected AddressEditModel Address { get; set; }
        = new();

    public void Add()
    {
        MudDialog.Close(DialogResult.Ok(Address));
    }

    public void Cancel()
    {
        MudDialog.Cancel();
    }
}
