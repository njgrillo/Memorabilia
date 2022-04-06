using Demo.Framework.Web;
using Memorabilia.Application.Features.Admin.People;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.People
{
    public partial class EditPersonHallOfFame : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Parameter]
        public int PersonId { get; set; }

        private SavePersonHallOfFamesViewModel _viewModel = new ();        

        protected async Task OnLoad()
        {
            var hallOfFames = (await QueryRouter.Send(new GetPersonHallOfFames.Query(PersonId))
                                                .ConfigureAwait(false)).Select(hof => new SavePersonHallOfFameViewModel(hof))
                                                                       .ToList();

            _viewModel = new SavePersonHallOfFamesViewModel(PersonId, hallOfFames);
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SavePersonHallOfFame.Command(PersonId, _viewModel.HallOfFames)).ConfigureAwait(false);
        }
    }
}
