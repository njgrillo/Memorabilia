namespace Memorabilia.Blazor.Pages.PrivateSigning.Promoter;

public partial class PromoterPrivateSigningCustomItemGroupDialog
{
    [Inject]
    public IMediator Mediator { get; set; }

    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }        

    protected List<PrivateSigningCustomItemGroupModel> CustomItemGroups { get; set; }
        = new();

    protected EditModeType EditMode
        = EditModeType.Add;

    protected PrivateSigningCustomItemGroupEditModel EditModel { get; set; }
        = new();

    protected override async Task OnInitializedAsync()
    {
        Entity.PrivateSigningCustomItemTypeGroup[] customItemTypeGroups
            = await Mediator.Send(new GetPrivateSigningCustomItemTypeGroups());

        foreach (string name in customItemTypeGroups.Select(group => group.PrivateSigningCustomItemGroup.Name).Distinct())
        {
            List<PrivateSigningCustomItemTypeGroupModel> items 
                = customItemTypeGroups.Where(x => x.PrivateSigningCustomItemGroup.Name == name)
                                      .Select(x => new PrivateSigningCustomItemTypeGroupModel(x))
                                      .ToList();

            CustomItemGroups.Add(new PrivateSigningCustomItemGroupModel(name, items));
        }
    }

    public void Add()
    {

    }

    public void Cancel()
    {
        MudDialog.Cancel();
    }

    public void Update()
    {

    }
}
