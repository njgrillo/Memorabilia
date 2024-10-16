namespace Memorabilia.Domain.Entities;

public class College : Entity
{
    public College() { }

    public College(string name, string abbreviation)
    {
        Abbreviation = abbreviation;
        Name = name;
    }

    public string Abbreviation { get; private set; }    

    public string Name { get; private set; }

    public virtual List<CollegeRetiredNumber> RetiredNumbers { get; set; }
        = [];

    public void DeleteRetiredNumbers(int[] ids)
    {
        CollegeRetiredNumber[] retiredNumbers = RetiredNumbers.Where(x => ids.Contains(x.Id)).ToArray();

        foreach (CollegeRetiredNumber retiredNumber in retiredNumbers)
        {
            RetiredNumbers.Remove(retiredNumber);
        }
    }

    public void Set(string name, string abbreviation)
    {
        Abbreviation = abbreviation;
        Name = name;
    }

    public void SetRetiredNumber(int id, int personId, string playerNumber)
    {
        if (id == 0)
        {
            RetiredNumbers.Add(new CollegeRetiredNumber(personId, Id, playerNumber));
            return;
        }

        CollegeRetiredNumber retiredNumber
            = RetiredNumbers.SingleOrDefault(x => x.Id == id);

        if (retiredNumber is null)
        {
            return;
        }

        retiredNumber.SetByPerson(personId, playerNumber);
    }
}
