namespace Memorabilia.Application.Features.Admin.People.Management.Colleges;

public class CollegesEditModel
{
    public CollegesEditModel() { }

    public CollegesEditModel(PersonModel person)
    {
        Colleges = person.Colleges
                         .Select(x => new CollegeEditModel(x))
                         .ToList();

        PersonId = person.Id;
    }

    public List<CollegeEditModel> Colleges { get; set; }
        = [];

    public int PersonId { get; private set; }
}
