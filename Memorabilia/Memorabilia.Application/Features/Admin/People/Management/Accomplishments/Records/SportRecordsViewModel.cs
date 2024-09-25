namespace Memorabilia.Application.Features.Admin.People.Management.Accomplishments.Records;

public class SportRecordsViewModel
{
    private readonly Entity.CareerRecord[] _careerRecords;
    private readonly Entity.SingleSeasonRecord[] _singleSeasonRecords;
    private readonly int _sportId;

    public SportRecordsViewModel() { }

    public SportRecordsViewModel(int sportId, Entity.CareerRecord[] careerRecords, Entity.SingleSeasonRecord[] singleSeasonRecords)
    {
        _careerRecords = careerRecords;
        _singleSeasonRecords = singleSeasonRecords;
        _sportId = sportId;
    }

    public Entity.CareerRecord[] CareerRecords
        => _careerRecords;

    public Entity.SingleSeasonRecord[] SingleSeasonRecords 
        => _singleSeasonRecords;

    public int SportId
        => _sportId;
}
