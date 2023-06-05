namespace Memorabilia.Blazor.Controls.Autographs.Inscriptions;

public partial class SuggestedInscriptions
{
    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Inject]
    public SuggestedInscriptionService SuggestedInscriptionService { get; set; }

    [Parameter]
    public EventCallback<SuggestedInscriptionModel> InscriptionSelected { get; set; }

    [Parameter]
    public int PersonId { get; set; }

    private bool _loaded;
    private int _personId;
    private string _search;
    private readonly SuggestedInscriptionsModel _viewModel = new();

    private bool FilterFunc1(SuggestedInscriptionModel inscription) 
        => FilterFunc(inscription, _search);

    protected override async Task OnInitializedAsync()
    {
        if (PersonId == 0 || (_loaded && _personId == PersonId))
            return;

        var person = await QueryRouter.Send(new GetPersonGeneric(PersonId));

        _viewModel.Items = SuggestedInscriptionService.GenerateInscriptions(person).ToList();

        _loaded = true;
        _personId = PersonId;
    }

    protected async Task Add(SuggestedInscriptionModel inscription)
    {
        await InscriptionSelected.InvokeAsync(inscription);
    }

    private static bool FilterFunc(SuggestedInscriptionModel inscription, string search)
    {
        return search.IsNullOrEmpty() ||
               inscription.Text.Contains(search, StringComparison.OrdinalIgnoreCase);
    }
}
