namespace Memorabilia.Blazor.Pages.Admin.People.Management.Awards;

public partial class AwardEditor
{
    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    protected AwardEditModel AwardEditModel
        = new();

    protected AwardsEditModel AwardsEditModel
        = new();

    protected EditModeType EditMode
        = EditModeType.Add;

    protected PersonModel SelectedPerson { get; set; }
        = new();

    private List<AwardEditModel> _awards
        => AwardsEditModel.Awards
                          .Where(award => !award.IsDeleted)
                          .OrderBy(award => award.Year)
                          .ToList();

    private string _years;

    private void Add()
    {
        if (AwardEditModel.AwardType is null)
            return;

        AwardsEditModel
            .Awards
            .AddRange(_years.ToIntArray().Select(year => new AwardEditModel(AwardEditModel.AwardType, SelectedPerson.Id, year)));

        AwardEditModel = new();

        _years = string.Empty;
    }

    private void Edit(AwardEditModel award)
    {
        AwardEditModel.Set(award.AwardType.Id, award.Year ?? 0);

        EditMode = EditModeType.Update;
    }

    private async void OnSave()
    {
        await Mediator.Send(new SaveAwards.Command(AwardsEditModel));

        Snackbar.Add("Awards were saved successfully!", Severity.Success);
    }

    private async Task OnSelectedPersonChanged(int personId)
    {
        if (personId == 0)
        {
            SelectedPerson = new();

            AwardsEditModel = new AwardsEditModel(SelectedPerson);
            AwardEditModel = new();

            return;
        }

        Entity.Person person = await Mediator.Send(new GetPerson(personId));

        SelectedPerson = new PersonModel(person);

        AwardsEditModel = new AwardsEditModel(SelectedPerson);
        AwardEditModel = new();
    }

    private void Update()
    {
        AwardEditModel award
            = AwardsEditModel.Awards.Single(x => (!x.IsNew && x.Id == AwardEditModel.Id) || x.TemporaryId == AwardEditModel.TemporaryId);

        award.Set(AwardEditModel.AwardType.Id, AwardEditModel.Year ?? 0);

        AwardEditModel = new();

        EditMode = EditModeType.Add;
    }
}
