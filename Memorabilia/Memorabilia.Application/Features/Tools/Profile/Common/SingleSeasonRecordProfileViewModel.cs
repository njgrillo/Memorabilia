using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Profile.Common
{
    public class SingleSeasonRecordProfileViewModel
    {
        private readonly SingleSeasonRecord _record;

        public SingleSeasonRecordProfileViewModel(SingleSeasonRecord record)
        {
            _record = record;
        }

        public string Amount => _record.Amount?.ToString("G29");

        public Domain.Constants.RecordType RecordType => Domain.Constants.RecordType.Find(RecordTypeId);

        public string RecordTypeAbbreviatedName => RecordType?.ToString();

        public int RecordTypeId => _record.RecordTypeId;

        public string RecordTypeName => RecordType?.Name;

        public int Year => _record.Year;

        public override string ToString()
        {
            return $"{Year} {Amount} {RecordTypeAbbreviatedName}";
        }
    }
}
