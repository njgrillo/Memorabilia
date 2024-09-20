namespace Memorabilia.Application.Features.Admin.People.Management.Colleges;

[AuthorizeByRole(Enum.Role.Admin)]
public class SaveColleges
{
    public class Handler(IPersonRepository personRepository)
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Person person;

            person = await personRepository.Get(command.PersonId);

            foreach (CollegeEditModel college in command.Colleges)
            {
                person.SetCollege(college.Id, college.College.Id, college.BeginYear, college.EndYear);
            }

            person.RemoveColleges(command.DeletedCollegeIds);

            await personRepository.Update(person);
        }
    }

    public class Command(CollegesEditModel editModel)
        : DomainCommand, ICommand
    {
        public int[] DeletedCollegeIds
            => editModel.Colleges
                        .Where(college => college.Id > 0 && college.IsDeleted)
                        .Select(college => college.Id)
                        .ToArray();

        public CollegeEditModel[] Colleges
            => editModel.Colleges
                        .Where(college => !college.IsDeleted)
                        .ToArray();

        public int PersonId
            => editModel.PersonId;
    }
}
