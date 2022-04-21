using Memorabilia.Application.Features.Admin.People;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Web.Controls.Person
{
    public partial class PersonRetiredNumberEditor : ComponentBase
    {
        [Parameter]
        public List<SavePersonRetiredNumberViewModel> RetiredNumbers { get; set; } = new();

        private SavePersonRetiredNumberViewModel _viewModel = new();

        private void Add()
        {
            RetiredNumbers.Add(_viewModel);

            _viewModel = new SavePersonRetiredNumberViewModel();
        }

        private void Remove(int franchiseId, int number)
        {
            var retiredNumber = RetiredNumbers.SingleOrDefault(retiredNumber => retiredNumber.FranchiseId == franchiseId &&
                                                                                retiredNumber.PlayerNumber == number);

            if (retiredNumber == null)
                return;

            retiredNumber.IsDeleted = true;
        }
    }
}
