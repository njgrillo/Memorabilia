using System.Linq;

namespace Memorabilia.Domain.Entities;

public class Franchise : Entity
{
    public Franchise() { }

    public Franchise(int sportLeagueLevelId, string name, string location, int foundYear)
    {
        SportLeagueLevelId = sportLeagueLevelId;
        Name = name;
        Location = location;
        FoundYear = foundYear;
        CreateDate = DateTime.UtcNow;
    }

    public virtual List<CareerFranchiseRecord> CareerFranchiseRecords { get; private set; }
        = [];

    public DateTime CreateDate { get; private set; }

    public int FoundYear { get; private set; }

    public string FullName => $"{Location} {Name}";

    public string ImageFileName { get; private set; }

    public DateTime? LastModifiedDate { get; private set; }

    public string Location { get; private set; }

    public string Name { get; private set; }

    public virtual List<SingleSeasonFranchiseRecord> SingleSeasonFranchiseRecords { get; private set; }
        = [];

    public virtual SportLeagueLevel SportLeagueLevel { get; private set; }

    public int SportLeagueLevelId { get; private set; }

    public string SportLeagueLevelName 
        => Constant.SportLeagueLevel.Find(SportLeagueLevelId)?.Name;

    public void DeleteCareerFranchiseRecords(int[] ids)
    {
        CareerFranchiseRecord[] records = CareerFranchiseRecords.Where(x => ids.Contains(x.Id)).ToArray();

        foreach (CareerFranchiseRecord record in records)
        {
            CareerFranchiseRecords.Remove(record);
        }
    }

    public void DeleteSingleSeasonFranchiseRecords(int[] ids)
    {
        SingleSeasonFranchiseRecord[] records = SingleSeasonFranchiseRecords.Where(x => ids.Contains(x.Id)).ToArray();

        foreach (SingleSeasonFranchiseRecord record in records)
        {
            SingleSeasonFranchiseRecords.Remove(record);
        }
    }

    public void Set(string name, string location, int foundYear)
    {
        Name = name;
        Location = location;
        FoundYear = foundYear;
    }

    public void SetCareerFranchiseRecord(int recordTypeId, string record, int[] personIds)
    {
        IEnumerable<CareerFranchiseRecord> careerFranchiseRecords 
            = CareerFranchiseRecords.Where(x => x.RecordTypeId == recordTypeId);

        foreach (int personId in personIds)
        {
            CareerFranchiseRecord careerFranchiseRecord 
                = careerFranchiseRecords.SingleOrDefault(x => (x.Person?.Id > 0 ? x.Person.Id : x.PersonId) == personId);

            if (careerFranchiseRecord is null)
            {
                CareerFranchiseRecords.Add(new CareerFranchiseRecord(personId, recordTypeId, Id, record));
                continue;
            }

            careerFranchiseRecord.Set(record);
        }

        foreach (CareerFranchiseRecord careerFranchiseRecord in careerFranchiseRecords.Where(x => x.Person is not null && !personIds.Contains(x.Person.Id)))
        {
            CareerFranchiseRecords.Remove(careerFranchiseRecord);
        }
    }

    public void SetSingleSeasonFranchiseRecord(int recordTypeId, string record, Tuple<int, int>[] personYears)
    {
        IEnumerable<SingleSeasonFranchiseRecord> singleSeasonFranchiseRecords
            = SingleSeasonFranchiseRecords.Where(x => x.RecordTypeId == recordTypeId);

        foreach (Tuple<int, int> personYear in personYears)
        {
            SingleSeasonFranchiseRecord singleSeasonFranchiseRecord 
                = singleSeasonFranchiseRecords.SingleOrDefault(x => (x.Person?.Id ?? x.PersonId) == personYear.Item1 && x.Year == personYear.Item2);

            if (singleSeasonFranchiseRecord is null)
            {
                SingleSeasonFranchiseRecords.Add(new SingleSeasonFranchiseRecord(personYear.Item1, recordTypeId, Id, personYear.Item2, record));
                continue;
            }

            singleSeasonFranchiseRecord.Set(record);
        }

        foreach (SingleSeasonFranchiseRecord singleSeasonFranchiseRecord in singleSeasonFranchiseRecords)
        {
            var personYear = new Tuple<int, int>(singleSeasonFranchiseRecord.PersonId, singleSeasonFranchiseRecord.Year);

            if (personYears.Any(x => x.Item1 == personYear.Item1 && x.Item2 == personYear.Item2))
                continue;

            SingleSeasonFranchiseRecords.Remove(singleSeasonFranchiseRecord);
        }
    }
}
