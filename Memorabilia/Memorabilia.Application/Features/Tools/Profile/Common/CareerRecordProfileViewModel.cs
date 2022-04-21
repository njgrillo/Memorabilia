using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Profile.Common
{
    public class CareerRecordProfileViewModel
    {
        private readonly CareerRecord _record;

        public CareerRecordProfileViewModel(CareerRecord record)
        {
            _record = record;
        }

        public int Amount => _record.Amount;

        public string CareerRecordTypeAbbreviatedName => Domain.Constants.RecordType.Find(CareerRecordTypeId)?.ToString();

        public int CareerRecordTypeId => _record.RecordTypeId;

        public override string ToString()
        {
            return $"{Amount:N0} {CareerRecordTypeAbbreviatedName}";
        }
    }
}
