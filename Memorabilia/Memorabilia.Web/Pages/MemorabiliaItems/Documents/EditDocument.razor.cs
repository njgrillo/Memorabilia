
using Memorabilia.Application.Features.Memorabilia.Document;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.MemorabiliaItems.Documents
{
    public partial class EditDocument : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Parameter]
        public int MemorabiliaId { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        private SaveDocumentViewModel _viewModel = new();

        protected async Task OnLoad()
        {
            var viewModel = await QueryRouter.Send(new GetDocument.Query(MemorabiliaId)).ConfigureAwait(false);

            _viewModel = new SaveDocumentViewModel(viewModel)
            {
                MemorabiliaId = MemorabiliaId
            };
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SaveDocument.Command(_viewModel)).ConfigureAwait(false);
        }
    }
}
