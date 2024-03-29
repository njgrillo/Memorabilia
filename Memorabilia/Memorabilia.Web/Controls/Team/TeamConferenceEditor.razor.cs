﻿using Memorabilia.Application.Features.Admin.Teams;
using Memorabilia.Domain.Constants;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Web.Controls.Team
{
    public partial class TeamConferenceEditor : ComponentBase
    {
        [Parameter]
        public List<SaveTeamConferenceViewModel> Conferences { get; set; } = new();

        [Parameter]
        public SportLeagueLevel SportLeagueLevel { get; set; }

        private SaveTeamConferenceViewModel _viewModel = new ();

        private void Add()
        {
            Conferences.Add(_viewModel);

            _viewModel = new SaveTeamConferenceViewModel();
        }

        private void Remove(int conferenceId, int? beginYear)
        {
            var conference = Conferences.SingleOrDefault(conference => conference.ConferenceId == conferenceId && conference.BeginYear == beginYear);

            if (conference == null)
                return;

            conference.IsDeleted = true;
        }
    }
}
