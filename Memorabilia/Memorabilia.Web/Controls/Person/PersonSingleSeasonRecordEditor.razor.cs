using Memorabilia.Application.Features.Admin.People;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Web.Controls.Person
{
    public partial class PersonSingleSeasonRecordEditor : ComponentBase
    {
        [Parameter]
        public List<SavePersonSingleSeasonRecordViewModel> SingleSeasonRecords { get; set; } = new();

        private SavePersonSingleSeasonRecordViewModel _viewModel = new();

        private void Add()
        {
            SingleSeasonRecords.Add(_viewModel);

            _viewModel = new SavePersonSingleSeasonRecordViewModel();
        }

        private void Remove(int recordTypeId)
        {
            var record = SingleSeasonRecords.SingleOrDefault(record => record.RecordTypeId == recordTypeId);

            if (record == null)
                return;

            record.IsDeleted = true;
        }
    }
}
