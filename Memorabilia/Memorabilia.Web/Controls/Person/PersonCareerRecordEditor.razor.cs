using Memorabilia.Application.Features.Admin.People;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Web.Controls.Person
{
    public partial class PersonCareerRecordEditor : ComponentBase
    {
        [Parameter]
        public List<SavePersonCareerRecordViewModel> CareerRecords { get; set; } = new();

        [Parameter]
        public Domain.Constants.RecordType[] RecordTypes { get; set; } = Domain.Constants.RecordType.All;

        private bool _canAdd = true;
        private bool _canEditRecordType = true;
        private bool _canUpdate;
        private SavePersonCareerRecordViewModel _viewModel = new();

        private void Add()
        {
            CareerRecords.Add(_viewModel);

            _viewModel = new SavePersonCareerRecordViewModel();
        }

        private void Edit(SavePersonCareerRecordViewModel record)
        {
            _viewModel.RecordTypeId = record.RecordTypeId;
            _viewModel.Amount = record.Amount;

            _canAdd = false;
            _canEditRecordType = false;
            _canUpdate = true;
        }

        private void Remove(int recordTypeId)
        {
            var record = CareerRecords.SingleOrDefault(record => record.RecordTypeId == recordTypeId);

            if (record == null)
                return;

            record.IsDeleted = true;
        }

        private void Update()
        {
            var record = CareerRecords.Single(record => record.RecordTypeId == _viewModel.RecordTypeId);

            record.Amount = _viewModel.Amount;

            _viewModel = new SavePersonCareerRecordViewModel();

            _canAdd = true;
            _canEditRecordType = true;
            _canUpdate = false;
        }
    }
}
