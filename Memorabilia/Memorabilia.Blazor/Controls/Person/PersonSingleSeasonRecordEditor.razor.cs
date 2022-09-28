#nullable disable

namespace Memorabilia.Blazor.Controls.Person
{
    public partial class PersonSingleSeasonRecordEditor : ComponentBase
    {
        [Parameter]
        public Domain.Constants.RecordType[] RecordTypes { get; set; } = Domain.Constants.RecordType.All;

        [Parameter]
        public List<SavePersonSingleSeasonRecordViewModel> SingleSeasonRecords { get; set; } = new();

        private bool _canAdd = true;
        private bool _canEditRecordType = true;
        private bool _canUpdate;
        private SavePersonSingleSeasonRecordViewModel _viewModel = new();

        private void Add()
        {
            SingleSeasonRecords.Add(_viewModel);

            _viewModel = new SavePersonSingleSeasonRecordViewModel();
        }

        private void Edit(SavePersonSingleSeasonRecordViewModel record)
        {
            _viewModel.RecordTypeId = record.RecordTypeId;
            _viewModel.Year = record.Year;
            _viewModel.Amount = record.Amount;

            _canAdd = false;
            _canEditRecordType = false;
            _canUpdate = true;
        }

        private void Remove(int recordTypeId)
        {
            var record = SingleSeasonRecords.SingleOrDefault(record => record.RecordTypeId == recordTypeId);

            if (record == null)
                return;

            record.IsDeleted = true;
        }

        private void Update()
        {
            var record = SingleSeasonRecords.Single(record => record.RecordTypeId == _viewModel.RecordTypeId);

            record.RecordTypeId = _viewModel.RecordTypeId;
            record.Year = _viewModel.Year;
            record.Amount = _viewModel.Amount;

            _viewModel = new SavePersonSingleSeasonRecordViewModel();

            _canAdd = true;
            _canEditRecordType = true;
            _canUpdate = false;
        }
    }
}
