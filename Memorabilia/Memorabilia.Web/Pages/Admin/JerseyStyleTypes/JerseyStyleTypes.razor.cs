
using Memorabilia.Application.Features.Admin;
using Memorabilia.Application.Features.Admin.JerseyStyleTypes;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.JerseyStyleTypes
{
    public partial class JerseyStyleTypes : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        private JerseyStyleTypesViewModel _viewModel;

        protected async Task OnDelete(SaveDomainViewModel viewModel)
        {
            await CommandRouter.Send(new SaveJerseyStyleType.Command(viewModel)).ConfigureAwait(false);
        }

        protected async Task OnLoad()
        {
            _viewModel = await QueryRouter.Send(new GetJerseyStyleTypes.Query()).ConfigureAwait(false);
        }
    }
}
