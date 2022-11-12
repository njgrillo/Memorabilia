using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People;

public class SavePersonCareerRecordViewModel : SaveViewModel
{
    public SavePersonCareerRecordViewModel() { }

    public SavePersonCareerRecordViewModel(CareerRecord record)
    {
        Id = record.Id;
        PersonId = record.PersonId;
        Record = record.Record;
        RecordType = Domain.Constants.RecordType.Find(record.RecordTypeId);
        SportIds = record.Person.Teams.Select(team => team.Team.Franchise.SportLeagueLevel.SportId).Distinct().ToArray();
    }    

    public int PersonId { get; set; }

    public string Record { get; set; }

    public Domain.Constants.RecordType RecordType { get; set; }

    public string RecordTypeName => RecordType?.Name;

    public int[] SportIds { get; }
}
