namespace Memorabilia.Blazor.Pages.Admin.People.Management.Drafts;

public partial class DraftEditor
{
    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    protected DraftEditModel DraftEditModel
        = new();

    protected DraftsEditModel DraftsEditModel
        = new();

    protected EditModeType EditMode
        = EditModeType.Add;

    protected PersonModel SelectedPerson { get; set; }
        = new();

    private List<DraftEditModel> _drafts
        => DraftsEditModel.Drafts
                           .Where(Draft => !Draft.IsDeleted)
                           .ToList();

    private void Add()
    {
        if (DraftEditModel.Franchise is null)
            return;

        DraftsEditModel.Drafts.Add(DraftEditModel);

        DraftEditModel = new DraftEditModel();
    }

    private void Edit(DraftEditModel draft)
    {
        DraftEditModel.Set(
            draft.Id, 
            draft.Franchise.Id, 
            draft.Year ?? 0, 
            draft.Round ?? 0,
            draft.Pick, 
            draft.Overall
            );

        EditMode = EditModeType.Update;
    }

    private void OnPickChange(int? value)
    {
        DraftEditModel.Pick = value;

        if ((DraftEditModel.Round ?? 0) != 1)
            return;

        DraftEditModel.Overall = DraftEditModel.Pick;
    }

    private async void OnSave()
    {
        await Mediator.Send(new SaveDrafts.Command(DraftsEditModel));

        Snackbar.Add("Drafts were saved successfully!", Severity.Success);
    }

    private async Task OnSelectedPersonChanged(int personId)
    {
        if (personId == 0)
        {
            SelectedPerson = new();

            DraftsEditModel = new DraftsEditModel(SelectedPerson);
            DraftEditModel = new();

            return;
        }

        Entity.Person person = await Mediator.Send(new GetPerson(personId));

        SelectedPerson = new PersonModel(person);

        DraftsEditModel = new DraftsEditModel(SelectedPerson);
        DraftEditModel = new();
    }

    private void Update()
    {
        DraftEditModel draft
            = DraftsEditModel.Drafts.Single(x => (!x.IsNew && x.Id == DraftEditModel.Id) || x.TemporaryId == DraftEditModel.TemporaryId);

        draft.Set(
            DraftEditModel.Franchise.Id, 
            DraftEditModel.Year ?? 0, 
            DraftEditModel.Round ?? 0, 
            DraftEditModel.Pick, 
            DraftEditModel.Overall
            );

        DraftEditModel = new();

        EditMode = EditModeType.Add;
    }
}
