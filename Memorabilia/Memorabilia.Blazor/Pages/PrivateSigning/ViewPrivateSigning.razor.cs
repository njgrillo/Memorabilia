using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Blazor.Pages.PrivateSigning;

public partial class ViewPrivateSigning
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Parameter]
    public string EncryptPrivateSigningId { get; set; }

    protected PrivateSigningModel Model { get; set; }
        = new();

    protected int PrivateSigningId { get; set; }

    protected override async Task OnInitializedAsync()
    {
        PrivateSigningId = DataProtectorService.DecryptId(EncryptPrivateSigningId);

        Model = new(await Mediator.Send(new GetPrivateSigning(PrivateSigningId)));
    }
}
