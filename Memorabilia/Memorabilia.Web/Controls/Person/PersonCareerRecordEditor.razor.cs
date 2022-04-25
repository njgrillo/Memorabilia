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

        private SavePersonCareerRecordViewModel _viewModel = new();

        private void Add()
        {
            CareerRecords.Add(_viewModel);

            _viewModel = new SavePersonCareerRecordViewModel();
        }

        private void Remove(int recordTypeId)
        {
            var record = CareerRecords.SingleOrDefault(record => record.RecordTypeId == recordTypeId);

            if (record == null)
                return;

            record.IsDeleted = true;
        }
    }
}
