using Memorabilia.Application.Features.Admin.People;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Web.Controls.Person
{
    public partial class PersonHallOfFameEditor : ComponentBase
    {
        [Parameter]
        public List<SavePersonHallOfFameViewModel> HallOfFames { get; set; } = new();

        private SavePersonHallOfFameViewModel _viewModel = new();

        private void Add()
        {
            HallOfFames.Add(_viewModel);

            _viewModel = new SavePersonHallOfFameViewModel();
        }

        private void Remove(int sportLeagueLevelId)
        {
            var hallOfFame = HallOfFames.SingleOrDefault(hallOfFame => hallOfFame.SportLeagueLevelId == sportLeagueLevelId);

            if (hallOfFame == null)
                return;

            hallOfFame.IsDeleted = true;
        }
    }
}
