using Demo.Framework.Web;
using Memorabilia.Application.Features.Memorabilia.CompactDisc;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.MemorabiliaItems.CompactDiscs
{
    public partial class EditCompactDisc : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Parameter]
        public int MemorabiliaId { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        private SaveCompactDiscViewModel _viewModel = new();

        protected async Task OnLoad()
        {
            var viewModel = await QueryRouter.Send(new GetCompactDisc.Query(MemorabiliaId)).ConfigureAwait(false);

            _viewModel = new SaveCompactDiscViewModel(viewModel)
            {
                MemorabiliaId = MemorabiliaId
            };
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SaveCompactDisc.Command(_viewModel)).ConfigureAwait(false);
        }
    }
}
