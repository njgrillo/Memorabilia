namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class CareerFranchiseRecordProfileModel(Entity.CareerFranchiseRecord record)
{
    public Constant.RecordType CareerRecordType
        => Constant.RecordType.Find(CareerRecordTypeId);

    public string CareerRecordTypeAbbreviatedName
        => CareerRecordType?.ToString();

    public int CareerRecordTypeId
        => record.RecordTypeId;

    public string CareerRecordTypeName
        => CareerRecordType?.Name;

    public Constant.Franchise Franchise
        => Constant.Franchise.Find(FranchiseId);

    public int FranchiseId
        => record.FranchiseId;

    public string FranchiseName
        => Franchise?.Name; 

    public string Record
        => record.Record;

    public override string ToString()
        => $"{Record} {CareerRecordTypeAbbreviatedName}";

    public bool Filter(string search)
    {
        return search.IsNullOrEmpty() ||
               CareerRecordTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               Record.Contains(search, StringComparison.OrdinalIgnoreCase);
    }
}
