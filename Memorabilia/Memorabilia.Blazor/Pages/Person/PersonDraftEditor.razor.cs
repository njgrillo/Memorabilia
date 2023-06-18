namespace Memorabilia.Blazor.Pages.Person;

public partial class PersonDraftEditor
{
    [Parameter]
    public List<PersonDraftEditModel> Drafts { get; set; } 
        = new();

    [Parameter]
    public List<int> SportIds { get; set; } 
        = new();

    protected PersonDraftEditModel Model 
        = new();

    protected EditModeType EditMode
        = EditModeType.Add;

    protected override void OnInitialized()
    {
        Model = new PersonDraftEditModel(SportIds.ToArray());
    }

    private void Add()
    {
        if (Model.Franchise == null)
            return;

        Drafts.Add(Model);

        Model = new PersonDraftEditModel(SportIds.ToArray());
    }

    private void Edit(PersonDraftEditModel draft)
    {
        Model.Franchise = draft.Franchise;
        Model.Year = draft.Year;
        Model.Round = draft.Round;
        Model.Pick = draft.Pick;
        Model.Overall = draft.Overall;

        EditMode = EditModeType.Update;
    }

    private void OnPickChange(int? value)
    {
        Model.Pick = value;

        if (Model.Round != 1)
            return;

        Model.Overall = Model.Pick;
    }

    private void Update()
    {
        PersonDraftEditModel draft 
            = Drafts.Single(draft => draft.Franchise.Id == Model.Franchise.Id);

        draft.Franchise = Model.Franchise;
        draft.Year = Model.Year;
        draft.Round = Model.Round;
        draft.Pick = Model.Pick;
        draft.Overall = Model.Overall;

        Model = new(SportIds.ToArray());

        EditMode = EditModeType.Add;
    }
}
