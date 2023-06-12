namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonDraftEditor : ComponentBase
{
    [Parameter]
    public List<PersonDraftEditModel> Drafts { get; set; } = new();

    [Parameter]
    public List<int> SportIds { get; set; } = new();

    private bool _canAdd = true;
    private bool _canEditFranchise = true;
    private bool _canUpdate;
    private PersonDraftEditModel _viewModel = new();

    protected override void OnInitialized()
    {
        _viewModel = new PersonDraftEditModel(SportIds.ToArray());
    }

    private void Add()
    {
        if (_viewModel.Franchise == null)
            return;

        Drafts.Add(_viewModel);

        _viewModel = new PersonDraftEditModel(SportIds.ToArray());
    }

    private void Edit(PersonDraftEditModel draft)
    {
        _viewModel.Franchise = draft.Franchise;
        _viewModel.Year = draft.Year;
        _viewModel.Round = draft.Round;
        _viewModel.Pick = draft.Pick;
        _viewModel.Overall = draft.Overall;

        _canAdd = false;
        _canEditFranchise = false;
        _canUpdate = true;
    }

    private void OnPickChange(int? value)
    {
        _viewModel.Pick = value;

        if (_viewModel.Round != 1)
            return;

        _viewModel.Overall = _viewModel.Pick;
    }

    private void Update()
    {
        var draft = Drafts.Single(draft => draft.Franchise.Id == _viewModel.Franchise.Id);

        draft.Franchise = _viewModel.Franchise;
        draft.Year = _viewModel.Year;
        draft.Round = _viewModel.Round;
        draft.Pick = _viewModel.Pick;
        draft.Overall = _viewModel.Overall;

        _viewModel = new PersonDraftEditModel(SportIds.ToArray());

        _canAdd = true;
        _canEditFranchise = true;
        _canUpdate = false;
    }
}
