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

    public virtual List<RetiredNumber> RetiredNumbers { get; private set; }
        = [];

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

    public void DeleteRetiredNumbers(int[] ids)
    {
        RetiredNumber[] retiredNumbers = RetiredNumbers.Where(x => ids.Contains(x.Id)).ToArray();

        foreach (RetiredNumber retiredNumber in retiredNumbers)
        {
            RetiredNumbers.Remove(retiredNumber);
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

    public void SetCareerFranchiseRecord(int id, int personId, int recordTypeId, string record)
    {
        if (id == 0)
        {
            CareerFranchiseRecords.Add(new CareerFranchiseRecord(personId, recordTypeId, Id, record));
            return;
        }

        CareerFranchiseRecord careerFranchiseRecord
            = CareerFranchiseRecords.SingleOrDefault(x => x.Id == id);

        if (careerFranchiseRecord is null)
        {
            return;
        }

        careerFranchiseRecord.Set(personId, record);
    }

    public void SetRetiredNumber(int id, int personId, string playerNumber)
    {
        if (id == 0)
        {
            RetiredNumbers.Add(new RetiredNumber(personId, Id, playerNumber));
            return;
        }

        RetiredNumber retiredNumber
            = RetiredNumbers.SingleOrDefault(x => x.Id == id);

        if (retiredNumber is null)
        {
            return;
        }

        retiredNumber.SetByPerson(personId, playerNumber);
    }

    public void SetSingleSeasonFranchiseRecord(int id, int personId, int recordTypeId, string record, int year)
    {
        if (id == 0)
        {
            SingleSeasonFranchiseRecords.Add(
                new SingleSeasonFranchiseRecord(
                    personId, 
                    recordTypeId, 
                    Id, 
                    year, 
                    record));

            return;
        }

        SingleSeasonFranchiseRecord singleSeasonFranchiseRecord
            = SingleSeasonFranchiseRecords.SingleOrDefault(x => x.Id == id);

        if (singleSeasonFranchiseRecord is null)
        {
            return;
        }

        singleSeasonFranchiseRecord.Set(personId, record, year);
    }
}
