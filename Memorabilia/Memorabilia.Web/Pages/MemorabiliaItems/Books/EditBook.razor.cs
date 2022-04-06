using Demo.Framework.Web;
using Memorabilia.Application.Features.Memorabilia.Book;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.MemorabiliaItems.Books
{
    public partial class EditBook : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Parameter]
        public int MemorabiliaId { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        private SaveBookViewModel _viewModel = new ();

        protected async Task OnLoad()
        {
            _viewModel = new SaveBookViewModel(await QueryRouter.Send(new GetBook.Query(MemorabiliaId)).ConfigureAwait(false));
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SaveBook.Command(_viewModel)).ConfigureAwait(false);
        }
    }
}
