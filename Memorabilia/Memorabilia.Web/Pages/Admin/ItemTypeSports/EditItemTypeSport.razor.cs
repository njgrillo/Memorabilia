
using Memorabilia.Application.Features.Admin.ItemTypeSports;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.ItemTypeSports
{
    public partial class EditItemTypeSport : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int Id { get; set; }

        private bool _displayItemType;
        private SaveItemTypeSportViewModel _viewModel = new ();

        protected async Task HandleValidSubmit()
        {
            await CommandRouter.Send(new SaveItemTypeSport.Command(_viewModel)).ConfigureAwait(false);
        }

        protected async Task OnLoad()
        {
            if (Id == 0)
            {
                _displayItemType = true;
                return;
            }

            _viewModel = new SaveItemTypeSportViewModel(await QueryRouter.Send(new GetItemTypeSport.Query(Id)).ConfigureAwait(false));
        }
    }
}
