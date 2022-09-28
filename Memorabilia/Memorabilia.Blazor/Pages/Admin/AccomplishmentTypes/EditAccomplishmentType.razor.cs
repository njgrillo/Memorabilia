#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.AccomplishmentTypes
{
    public partial class EditAccomplishmentType : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int Id { get; set; }

        private const string DomainTypeName = "Accomplishment Type";
        private const string ImagePath = "images/accomplishmenttypes.jpg";
        private readonly string _navigationPath = $"{DomainTypeName.Replace(" ", "")}s";
        private SaveDomainViewModel _viewModel;

        protected override void OnInitialized()
        {
            _viewModel = new SaveDomainViewModel(Id, DomainTypeName, ImagePath, _navigationPath);
        }

        protected async Task OnLoad()
        {
            _viewModel = new SaveDomainViewModel(await QueryRouter.Send(new GetAccomplishmentType.Query(Id)).ConfigureAwait(false),
                                                 DomainTypeName,
                                                 ImagePath,
                                                 _navigationPath);
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SaveAccomplishmentType.Command(_viewModel)).ConfigureAwait(false);
        }
    }
}
