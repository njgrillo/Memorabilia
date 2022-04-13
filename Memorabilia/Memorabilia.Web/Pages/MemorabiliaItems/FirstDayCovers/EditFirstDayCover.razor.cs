using Demo.Framework.Web;
using Memorabilia.Application.Features.Memorabilia.FirstDayCover;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.MemorabiliaItems.FirstDayCovers
{
    public partial class EditFirstDayCover : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int MemorabiliaId { get; set; }

        private SaveFirstDayCoverViewModel _viewModel = new ();

        protected async Task OnLoad()
        {
            _viewModel = new SaveFirstDayCoverViewModel(await QueryRouter.Send(new GetFirstDayCover.Query(MemorabiliaId)).ConfigureAwait(false))
            {
                MemorabiliaId = MemorabiliaId
            };
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SaveFirstDayCover.Command(_viewModel)).ConfigureAwait(false);
        }

        private void SelectedSportIdsChanged(IEnumerable<int> sportIds)
        {
            _viewModel.SportIds = sportIds.ToList();
        }
    }
}
