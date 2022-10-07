#nullable disable

namespace Memorabilia.Blazor.Pages.MemorabiliaItems.JerseyNumbers
{
    public partial class EditJerseyNumber : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Parameter]
        public int MemorabiliaId { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        private SaveJerseyNumberViewModel _viewModel = new();

        protected async Task OnLoad()
        {
            _viewModel = new SaveJerseyNumberViewModel(await QueryRouter.Send(new GetJerseyNumber.Query(MemorabiliaId)).ConfigureAwait(false))
            {
                MemorabiliaId = MemorabiliaId
            };
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SaveJerseyNumber.Command(_viewModel)).ConfigureAwait(false);
        }

        private void SelectedPersonChanged(SavePersonViewModel person)
        {
            _viewModel.Person = person;
        }

        private void SelectedTeamChanged(SaveTeamViewModel team)
        {
            _viewModel.Team = team;
        }
    }
}
