namespace Memorabilia.Application.Features.Admin.Colleges.Management.RetiredNumbers;

[AuthorizeByRole(Enum.Role.Admin)]
public class SaveCollegeRetiredNumbers
{
    public class Handler(ICollegeRepository collegeRepository)
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.College college = await collegeRepository.Get(command.CollegeId);

            if (college is null)
                return;

            foreach (CollegeRetiredNumberEditModel retiredNumber in command.RetiredNumbers)
            {
                if (retiredNumber.PlayerNumber.IsNullOrEmpty() || retiredNumber.GetPersonId() == 0)
                    continue;

                college.SetRetiredNumber(
                    retiredNumber.Id,
                    retiredNumber.GetPersonId(),
                    retiredNumber.PlayerNumber
                    );
            }

            college.DeleteRetiredNumbers(command.DeletedRetiredNumberIds);

            await collegeRepository.Update(college);
        }
    }

    public class Command(CollegeRetiredNumbersEditModel editModel)
        : DomainCommand, ICommand
    {
        public int CollegeId
            => editModel.College?.Id ?? 0;

        public int[] DeletedRetiredNumberIds
            => editModel.RetiredNumbers
                        .Where(x => x.Id > 0 && x.IsDeleted)
                        .Select(x => x.Id)
                        .ToArray();

        public List<CollegeRetiredNumberEditModel> RetiredNumbers
            => editModel.RetiredNumbers
                        .Where(x => !x.IsDeleted)
                        .ToList();
    }
}
