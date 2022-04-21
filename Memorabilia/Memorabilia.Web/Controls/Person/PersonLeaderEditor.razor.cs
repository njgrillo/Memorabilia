using Memorabilia.Application.Features.Admin.People;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Web.Controls.Person
{
    public partial class PersonLeaderEditor : ComponentBase
    {
        [Parameter]
        public List<SavePersonLeaderViewModel> Leaders { get; set; } = new();

        private SavePersonLeaderViewModel _viewModel = new();

        private void Add()
        {
            Leaders.Add(_viewModel);

            _viewModel = new SavePersonLeaderViewModel();
        }

        private void Remove(int leaderTypeId, int year)
        {
            var leader = Leaders.SingleOrDefault(leader => leader.LeaderTypeId == leaderTypeId && leader.Year == year);

            if (leader == null)
                return;

            leader.IsDeleted = true;
        }
    }
}
