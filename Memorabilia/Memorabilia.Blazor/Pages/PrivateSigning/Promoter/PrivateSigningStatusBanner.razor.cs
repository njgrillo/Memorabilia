namespace Memorabilia.Blazor.Pages.PrivateSigning.Promoter;

public partial class PrivateSigningStatusBanner
{
    [Parameter]
    public string PublishedMessage { get; set; }

    [Parameter]
    public Severity PublishedSeverity { get; set; }
        = Severity.Info;

    [Parameter]
    public string StatusMessage { get; set; }

    [Parameter]
    public Severity StatusSeverity { get; set; }
        = Severity.Info;
}
