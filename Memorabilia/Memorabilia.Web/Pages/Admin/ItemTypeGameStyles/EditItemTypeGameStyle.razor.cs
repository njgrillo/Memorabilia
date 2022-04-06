using Demo.Framework.Web;
using Memorabilia.Application.Features.Admin.ItemTypeGameStyle;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.ItemTypeGameStyles
{
    public partial class EditItemTypeGameStyle : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int Id { get; set; }

        private bool _displayItemType;
        private SaveItemTypeGameStyleViewModel _viewModel = new ();

        protected async Task HandleValidSubmit()
        {
            await CommandRouter.Send(new SaveItemTypeGameStyle.Command(_viewModel)).ConfigureAwait(false);
        }

        protected async Task OnLoad()
        {
            if (Id == 0)
            {
                _displayItemType = true;
                return;
            }

            _viewModel = new SaveItemTypeGameStyleViewModel(await QueryRouter.Send(new GetItemTypeGameStyle.Query(Id)).ConfigureAwait(false));
        }
    }
}
