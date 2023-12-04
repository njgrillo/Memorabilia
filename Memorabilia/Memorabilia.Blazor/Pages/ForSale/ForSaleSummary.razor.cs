namespace Memorabilia.Blazor.Pages.ForSale;

public partial class ForSaleSummary
{
    [Inject]
    public IMediator Mediator { get; set; }

    protected ForSaleSummaryModel Model { get; set; }
        = new();

    protected override async Task OnInitializedAsync()
    {
        Model = await Mediator.Send(new GetForSaleSummary());
    }
}
