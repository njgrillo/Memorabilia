namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class SingleSeasonFranchiseRecordProfileModel(Entity.SingleSeasonFranchiseRecord record)
{
    public Constant.Franchise Franchise
        => Constant.Franchise.Find(record.FranchiseId);

    public int FranchiseId
        => record.FranchiseId;

    public string FranchiseName
        => Franchise?.Name;

    public string Record
        => record.Record;

    public Constant.RecordType RecordType
        => Constant.RecordType.Find(RecordTypeId);

    public string RecordTypeAbbreviatedName
        => RecordType?.ToString();

    public int RecordTypeId
        => record.RecordTypeId;

    public string RecordTypeName
        => RecordType?.Name;

    public int Year
        => record.Year;

    public override string ToString()
        => $"{Year} {Record} {RecordTypeAbbreviatedName}";

    public bool Filter(string search)
    {
        bool isYear = int.TryParse(search, out int year);

        return search.IsNullOrEmpty() ||
               (isYear && Year == year) ||
               Record.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               RecordTypeName.Contains(search, StringComparison.OrdinalIgnoreCase);
    }
}
