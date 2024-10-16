namespace Memorabilia.Application.Features.Admin.People.Management.Colleges;

public class ManageCollegesEditModel
{
    public ManageCollegesEditModel() { }

    public ManageCollegesEditModel(PersonModel person)
    {
        Colleges = person.Colleges
                         .Select(x => new ManageCollegeEditModel(x))
                         .ToList();

        PersonId = person.Id;
    }

    public List<ManageCollegeEditModel> Colleges { get; set; }
        = [];

    public int PersonId { get; private set; }
}
