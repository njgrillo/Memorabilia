using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Blazor.Pages.Membership;

public partial class SubscriberLevel
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }    

    [Parameter]
    public EventCallback OnSelect { get; set; }

    [Parameter]
    public Enum.Role Role { get; set; }

    [Parameter]
    public decimal? SubscriptionPrice { get; set; }

    [Parameter]
    public string Title { get; set; }

    protected Feature[] Features { get; set; }
        = [];

    private bool _canSelect
        = true;

    private string _price
        => SubscriptionPrice.HasValue
            ? $" - {SubscriptionPrice.Value:c}"
            : string.Empty;

    protected override void OnInitialized()
    {
        Entity.UserRole userRole 
            = ApplicationStateService.CurrentUser?.Roles?.FirstOrDefault();

        if (userRole != null)
            _canSelect = userRole.RoleId != (int)Role;

        Features =
            Role switch
            {
                Enum.Role.NonSubscriber => Feature.Free,
                Enum.Role.Promoter => Feature.All,
                Enum.Role.SubscriberTier1 => Feature.Tier1,
                Enum.Role.SubscriberTier2 => Feature.Tier2,
                _ => throw new ArgumentException(message: "invalid role", paramName: nameof(Role)),
            };
    }

    protected async Task Select()
    {
        await OnSelect.InvokeAsync();
    }

    protected void ShowDescription(Feature feature)
    {
        //TODO: Finish implementation
    }
}
