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

        public int Amount => _record.Amount;

        public string CareerRecordTypeAbbreviatedName => Domain.Constants.RecordType.Find(CareerRecordTypeId)?.ToString();

        public int CareerRecordTypeId => _record.RecordTypeId;

        public int Year => _record.Year;

        public override string ToString()
        {
            return $"{Year} {Amount:N0} {CareerRecordTypeAbbreviatedName}";
        }
    }
}
