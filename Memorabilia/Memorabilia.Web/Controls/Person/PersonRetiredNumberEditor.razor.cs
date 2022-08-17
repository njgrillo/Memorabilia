using Memorabilia.Application.Features.Admin.People;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Web.Controls.Person
{
    public partial class PersonRetiredNumberEditor : ComponentBase
    {
        [Parameter]
        public Domain.Constants.Franchise[] Franchises { get; set; } = Domain.Constants.Franchise.All;

        [Parameter]
        public List<SavePersonRetiredNumberViewModel> RetiredNumbers { get; set; } = new();

        private bool _canAdd = true;
        private bool _canEditFranchise = true;
        private bool _canUpdate;
        private SavePersonRetiredNumberViewModel _viewModel = new();

        private void Add()
        {
            RetiredNumbers.Add(_viewModel);

            _viewModel = new SavePersonRetiredNumberViewModel();
        }

        private void Edit(SavePersonRetiredNumberViewModel retiredNumber)
        {
            _viewModel.FranchiseId = retiredNumber.FranchiseId;
            _viewModel.PlayerNumber = retiredNumber.PlayerNumber;

            _canAdd = false;
            _canEditFranchise = false;
            _canUpdate = true;
        }

        private void Remove(int franchiseId, int? number)
        {
            var retiredNumber = RetiredNumbers.SingleOrDefault(retiredNumber => retiredNumber.FranchiseId == franchiseId &&
                                                                                retiredNumber.PlayerNumber == (number ?? 0));

            if (retiredNumber == null)
                return;

            retiredNumber.IsDeleted = true;
        }

        private void Update()
        {
            var number = RetiredNumbers.Single(number => number.FranchiseId == _viewModel.FranchiseId);

            number.FranchiseId = _viewModel.FranchiseId;
            number.PlayerNumber = _viewModel.PlayerNumber;

            _viewModel = new SavePersonRetiredNumberViewModel();

            _canAdd = true;
            _canEditFranchise = true;
            _canUpdate = false;
        }
    }
}
