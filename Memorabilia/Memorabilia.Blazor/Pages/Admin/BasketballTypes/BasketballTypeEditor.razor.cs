﻿#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.BasketballTypes;

public partial class BasketballTypeEditor : ComponentBase, IEditDomainItem
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public int Id { get; set; }

    private const string DomainTypeName = "Basketball Type";
    private const string ImagePath = "images/basketballtypes.jpg";
    private readonly string NavigationPath = $"{DomainTypeName.Replace(" ", "")}s";

    private SaveDomainViewModel ViewModel;

    protected override void OnInitialized()
    {
        ViewModel = new SaveDomainViewModel(Id, DomainTypeName, ImagePath, NavigationPath);
    }

    public async Task OnLoad()
    {
        ViewModel = new SaveDomainViewModel(await QueryRouter.Send(new GetBasketballType.Query(Id)).ConfigureAwait(false),
                                             DomainTypeName,
                                             ImagePath,
                                             NavigationPath);
    }

    public async Task OnSave()
    {
        await CommandRouter.Send(new SaveBasketballType.Command(ViewModel)).ConfigureAwait(false);
    }
}
