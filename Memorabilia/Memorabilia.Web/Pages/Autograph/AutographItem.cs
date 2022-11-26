namespace Memorabilia.Web.Pages.Autograph;

public class AutographItem : WebPage
{
    [Parameter]
    public int AutographId { get; set; }

    [Parameter]
    public int MemorabiliaId { get; set; }
}
