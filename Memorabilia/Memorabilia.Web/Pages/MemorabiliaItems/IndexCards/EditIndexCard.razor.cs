
using Memorabilia.Application.Features.Memorabilia.IndexCard;
using Memorabilia.Domain.Constants;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.MemorabiliaItems.IndexCards
{
    public partial class EditIndexCard : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Parameter]
        public int MemorabiliaId { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        private SaveIndexCardViewModel _viewModel = new();

        protected async Task OnLoad()
        {
            var viewModel = await QueryRouter.Send(new GetIndexCard.Query(MemorabiliaId)).ConfigureAwait(false);

            if (viewModel.Size == null)
            {
                SetDefaults();
                return;
            }

            _viewModel = new SaveIndexCardViewModel(viewModel)
            {
                MemorabiliaId = MemorabiliaId
            };
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SaveIndexCard.Command(_viewModel)).ConfigureAwait(false);
        }

        private void SetDefaults()
        {
            _viewModel.MemorabiliaId = MemorabiliaId;
            _viewModel.SizeId = Size.ThreeByFive.Id;
        }
    }
}
