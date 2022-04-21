using Demo.Framework.Web;
using Memorabilia.Application.Features.Admin;
using Memorabilia.Application.Features.Admin.Colleges;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.Colleges
{
    public partial class Colleges : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        private CollegesViewModel _viewModel;

        protected async Task OnDelete(SaveDomainViewModel viewModel)
        {
            await CommandRouter.Send(new SaveCollege.Command(viewModel)).ConfigureAwait(false);
        }

        protected async Task OnLoad()
        {
            _viewModel = await QueryRouter.Send(new GetColleges.Query()).ConfigureAwait(false);
        }
    }
}
