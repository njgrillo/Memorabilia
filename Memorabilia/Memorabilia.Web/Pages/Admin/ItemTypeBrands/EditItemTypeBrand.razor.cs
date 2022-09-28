
using Memorabilia.Application.Features.Admin.ItemTypeBrand;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.ItemTypeBrands
{
    public partial class EditItemTypeBrand : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int Id { get; set; }

        private bool _displayItemType;
        private SaveItemTypeBrandViewModel _viewModel = new ();

        protected async Task HandleValidSubmit()
        {
            await CommandRouter.Send(new SaveItemTypeBrand.Command(_viewModel)).ConfigureAwait(false);
        }

        protected async Task OnLoad()
        {
            if (Id == 0)
            {
                _displayItemType = true;
                return;
            }

            _viewModel = new SaveItemTypeBrandViewModel(await QueryRouter.Send(new GetItemTypeBrand.Query(Id)).ConfigureAwait(false));
        }
    }
}
