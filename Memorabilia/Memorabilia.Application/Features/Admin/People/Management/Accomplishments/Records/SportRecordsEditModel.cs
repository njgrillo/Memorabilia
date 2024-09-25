namespace Memorabilia.Application.Features.Admin.People.Management.Accomplishments.Records;

public class SportRecordsEditModel : EditModel
{
    public SportRecordsEditModel() { }

    public SportRecordsEditModel(int sportId, Entity.CareerRecord[] careerRecords, Entity.SingleSeasonRecord[] singleSeasonRecords)
    {
        SportId = sportId;        

        foreach (Constant.RecordType recordType in Constant.RecordType.GetAll(Constant.Sport.Find(SportId)))
        {
            if (careerRecords.Any(x => x.RecordTypeId == recordType.Id))
            {
                AddCareerRecords(careerRecords.Where(x => x.RecordTypeId == recordType.Id));
            }
            else
            {
                CareerRecords.Add(new CareerRecordEditModel(new Entity.CareerRecord(recordType.Id)));
            }

            if (singleSeasonRecords.Any(x => x.RecordTypeId == recordType.Id))
            {
                AddSingleSeasonRecords(singleSeasonRecords.Where(x => x.RecordTypeId == recordType.Id));
            }
            else
            {
                SingleSeasonRecords.Add(new SingleSeasonRecordEditModel(new Entity.SingleSeasonRecord(recordType.Id)));
            }
        }
    }

    public List<CareerRecordEditModel> CareerRecords { get; set; }
        = [];

    public List<SingleSeasonRecordEditModel> SingleSeasonRecords { get; set; }
        = [];

    public int SportId { get; set; }

    private void AddCareerRecords(IEnumerable<Entity.CareerRecord> careerRecords)
    {
        CareerRecords.AddRange(careerRecords.Select(careerRecord => new CareerRecordEditModel(careerRecord)));
    }

    private void AddSingleSeasonRecords(IEnumerable<Entity.SingleSeasonRecord> singleSeasonRecords)
    {
        SingleSeasonRecords.AddRange(singleSeasonRecords.Select(singleSeasonRecord => new SingleSeasonRecordEditModel(singleSeasonRecord)));
    }
}
