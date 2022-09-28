namespace Memorabilia.Web.Pages.Autograph
{
    public partial class EditAutograph : ComponentBase
    {
        [Parameter]
        public int AutographId { get; set; }     

        [Parameter]
        public int MemorabiliaId { get; set; }    
    }
}
