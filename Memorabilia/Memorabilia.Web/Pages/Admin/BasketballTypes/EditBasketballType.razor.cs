
using Memorabilia.Application.Features.Admin;
using Memorabilia.Application.Features.Admin.BasketballTypes;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.BasketballTypes
{
    public partial class EditBasketballType : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int Id { get; set; }

        private const string DomainTypeName = "Basketball Type";
        private const string ImagePath = "images/basketballtypes.jpg";
        private readonly string NavigationPath = $"{DomainTypeName.Replace(" ", "")}s";

        private SaveDomainViewModel _viewModel;

        protected override void OnInitialized()
        {
            _viewModel = new SaveDomainViewModel(Id, DomainTypeName, ImagePath, NavigationPath);
        }

        protected async Task OnLoad()
        {
            _viewModel = new SaveDomainViewModel(await QueryRouter.Send(new GetBasketballType.Query(Id)).ConfigureAwait(false),
                                                 DomainTypeName,
                                                 ImagePath,
                                                 NavigationPath);
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SaveBasketballType.Command(_viewModel)).ConfigureAwait(false);
        }
    }
}
