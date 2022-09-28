
using Memorabilia.Application.Features.Admin;
using Memorabilia.Application.Features.Admin.FranchiseHallOfFameTypes;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.FranchiseHallOfFameTypes
{
    public partial class EditFranchiseHallOfFameType : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int Id { get; set; }

        private const string DomainTypeName = "Franchise Hall of Fame Type";
        private const string ImagePath = "images/franchisehalloffametypes.jpg";
        private readonly string _navigationPath = $"{DomainTypeName.Replace(" ", "")}s";
        private SaveDomainViewModel _viewModel;

        protected override void OnInitialized()
        {
            _viewModel = new SaveDomainViewModel(Id, DomainTypeName, ImagePath, _navigationPath);
        }

        protected async Task OnLoad()
        {
            _viewModel = new SaveDomainViewModel(await QueryRouter.Send(new GetFranchiseHallOfFameType.Query(Id)).ConfigureAwait(false),
                                                 DomainTypeName,
                                                 ImagePath,
                                                 _navigationPath);
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SaveFranchiseHallOfFameType.Command(_viewModel)).ConfigureAwait(false);
        }
    }
}
