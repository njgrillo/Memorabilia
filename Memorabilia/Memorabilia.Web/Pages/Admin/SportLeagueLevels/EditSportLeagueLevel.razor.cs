﻿using Memorabilia.Application.Features.Admin.SportLeagueLevels;

namespace Memorabilia.Web.Pages.Admin.SportLeagueLevels
{
    public partial class EditSportLeagueLevel : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int Id { get; set; }

        private SaveSportLeagueLevelViewModel _viewModel = new ();

        protected async Task HandleValidSubmit()
        {
            await CommandRouter.Send(new SaveSportLeagueLevel(_viewModel));
        }

        protected async Task OnLoad()
        {
            if (Id == 0)
                return;

            _viewModel = new SaveSportLeagueLevelViewModel(await QueryRouter.Send(new GetSportLeagueLevel(Id)));
        }
    }
}
