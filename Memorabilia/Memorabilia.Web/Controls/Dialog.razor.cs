using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Memorabilia.Web.Controls
{
    public partial class Dialog : ComponentBase
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        [Parameter] public string ButtonText { get; set; }

        [Parameter] public Color Color { get; set; }

        [Parameter] public string ContentText { get; set; }

        public void Cancel()
        {
            MudDialog.Cancel();
        }

        public void Submit() 
        {
            MudDialog.Close(DialogResult.Ok(true));
        }       
    }
}
