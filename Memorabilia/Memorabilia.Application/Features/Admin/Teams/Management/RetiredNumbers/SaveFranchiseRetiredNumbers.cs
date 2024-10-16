namespace Memorabilia.Application.Features.Admin.Teams.Management.RetiredNumbers;

[AuthorizeByRole(Enum.Role.Admin)]
public class SaveFranchiseRetiredNumbers
{
    public class Handler(IFranchiseRepository franchiseRepository)
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Franchise franchise = await franchiseRepository.Get(command.FranchiseId);

            if (franchise is null)
                return;

            foreach (FranchiseRetiredNumberEditModel retiredNumber in command.RetiredNumbers)
            {
                if (retiredNumber.PlayerNumber.IsNullOrEmpty() || retiredNumber.GetPersonId() == 0)
                    continue;

                franchise.SetRetiredNumber(
                    retiredNumber.Id,
                    retiredNumber.GetPersonId(),
                    retiredNumber.PlayerNumber
                    );
            }

            franchise.DeleteRetiredNumbers(command.DeletedRetiredNumberIds);

            await franchiseRepository.Update(franchise);
        }
    }

    public class Command(FranchiseRetiredNumbersEditModel editModel)
        : DomainCommand, ICommand
    {
        public int[] DeletedRetiredNumberIds
            => editModel.RetiredNumbers
                        .Where(x => x.Id > 0 && x.IsDeleted)
                        .Select(x => x.Id)
                        .ToArray();

        public int FranchiseId
            => editModel.Franchise?.Id ?? 0;

        public List<FranchiseRetiredNumberEditModel> RetiredNumbers
            => editModel.RetiredNumbers
                        .Where(x => !x.IsDeleted)
                        .ToList();
    }
}
