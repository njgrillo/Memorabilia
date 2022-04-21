using Memorabilia.Application.Features.Admin.People;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Web.Controls.Person
{
    public partial class PersonFranchiseHallOfFameEditor : ComponentBase
    {
        [Parameter]
        public List<SavePersonFranchiseHallOfFameViewModel> FranchiseHallOfFames { get; set; } = new();

        private SavePersonFranchiseHallOfFameViewModel _viewModel = new();

        private void Add()
        {
            FranchiseHallOfFames.Add(_viewModel);

            _viewModel = new SavePersonFranchiseHallOfFameViewModel();
        }

        private void Remove(int franchiseId)
        {
            var hallOfFame = FranchiseHallOfFames.SingleOrDefault(hallOfFame => hallOfFame.FranchiseId == franchiseId);

            if (hallOfFame == null)
                return;

            hallOfFame.IsDeleted = true;
        }
    }
}
