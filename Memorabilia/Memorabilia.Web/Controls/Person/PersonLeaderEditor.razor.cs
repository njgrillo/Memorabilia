using Memorabilia.Application.Features.Admin.People;
using Memorabilia.Domain.Extensions;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Web.Controls.Person
{
    public partial class PersonLeaderEditor : ComponentBase
    {
        [Parameter]
        public List<SavePersonLeaderViewModel> Leaders { get; set; } = new();

        [Parameter]
        public Domain.Constants.LeaderType[] LeaderTypes { get; set; } = Domain.Constants.LeaderType.All;

        private SavePersonLeaderViewModel _viewModel = new();
        private string _years;

        private void Add()
        {
            foreach (var year in _years.ToIntArray())
            {
                Leaders.Add(new SavePersonLeaderViewModel() { LeaderTypeId = _viewModel.LeaderTypeId, Year = year });
            }            

            _viewModel = new SavePersonLeaderViewModel();
            _years = string.Empty;
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
