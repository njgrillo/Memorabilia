
using Memorabilia.Application.Features.Admin;
using Memorabilia.Application.Features.Admin.Occupations;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.Occupations
{
    public partial class EditOccupation : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int Id { get; set; }

        private const string DomainTypeName = "Occupation";
        private const string ImagePath = "images/occupations.jpg";
        private const string NavigationPath = $"{DomainTypeName}s";

        private SaveDomainViewModel _viewModel;

        protected override void OnInitialized()
        {
            _viewModel = new SaveDomainViewModel(Id, DomainTypeName, ImagePath, NavigationPath);
        }

        protected async Task OnLoad()
        {
            _viewModel = new SaveDomainViewModel(await QueryRouter.Send(new GetOccupation.Query(Id)).ConfigureAwait(false),
                                                 DomainTypeName,
                                                 ImagePath,
                                                 NavigationPath);
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SaveOccupation.Command(_viewModel)).ConfigureAwait(false);
        }
    }
}
