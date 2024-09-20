namespace Memorabilia.Blazor.Pages.Admin.Management.Nicknames;

public partial class NicknameEditor
{
    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    protected NicknameEditModel NicknameEditModel
        = new();

    protected NicknamesEditModel NicknamesEditModel
        = new();

    protected EditModeType EditMode
        = EditModeType.Add;

    protected PersonModel SelectedPerson { get; set; }
        = new();

    private List<NicknameEditModel> _nicknames
        => NicknamesEditModel.Nicknames
                             .Where(nickname => !nickname.IsDeleted)
                             .ToList();

    private void Add()
    {
        if (NicknameEditModel.Nickname.IsNullOrEmpty())
            return;

        NicknamesEditModel.Nicknames.Add(NicknameEditModel);

        NicknameEditModel = new NicknameEditModel();
    }

    private void Edit(NicknameEditModel nickname)
    {
        NicknameEditModel.Set(nickname.Id, nickname.Nickname);

        EditMode = EditModeType.Update;
    }

    private async void OnSave()
    {
        await Mediator.Send(new SaveNicknames.Command(NicknamesEditModel));

        Snackbar.Add("Nicknames were saved successfully!", Severity.Success);
    }

    private async Task OnSelectedPersonChanged(int personId)
    {
        if (personId == 0)
        {
            SelectedPerson = new();

            NicknamesEditModel = new NicknamesEditModel(SelectedPerson);
            NicknameEditModel = new();

            return;
        }

        Entity.Person person = await Mediator.Send(new GetPerson(personId));

        SelectedPerson = new PersonModel(person);

        NicknamesEditModel = new NicknamesEditModel(SelectedPerson);
        NicknameEditModel = new();
    }    

    private void Update()
    {
        NicknameEditModel nickname
            = NicknamesEditModel.Nicknames
                                .Single(x => (!x.IsNew && x.Id == NicknameEditModel.Id) || x.TemporaryId == NicknameEditModel.TemporaryId);

        nickname.Set(NicknameEditModel.Nickname);

        NicknameEditModel = new();

        EditMode = EditModeType.Add;
    }
}
