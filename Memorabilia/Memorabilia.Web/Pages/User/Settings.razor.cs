using Memorabilia.Application.Features.User.Settings;
using Microsoft.AspNetCore.Components;

namespace Memorabilia.Web.Pages.User
{
    public partial class Settings : ComponentBase
    {
        private readonly UserSettingsViewModel _viewModel = new();
    }
}
