using Demo.Framework.Web;
using Memorabilia.Application.Features.Admin.People;
using Microsoft.AspNetCore.Components;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.People
{
    public partial class EditPersonOccupation : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int PersonId { get; set; }

        private SavePersonOccupationsViewModel _viewModel = new();    

        protected async Task OnLoad()
        {
            var occupations = (await QueryRouter.Send(new GetPersonOccupations.Query(PersonId))
                                                .ConfigureAwait(false)).Select(personOccupation => new SavePersonOccupationViewModel(personOccupation))
                                                                       .ToList();

            _viewModel = new SavePersonOccupationsViewModel(PersonId, occupations);
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SavePersonOccupation.Command(PersonId, _viewModel.PersonOccupations)).ConfigureAwait(false);
        }
    }
}
