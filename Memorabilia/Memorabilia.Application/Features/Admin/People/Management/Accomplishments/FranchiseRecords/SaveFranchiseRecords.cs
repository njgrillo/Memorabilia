namespace Memorabilia.Application.Features.Admin.People.Management.Accomplishments.FranchiseRecords;

[AuthorizeByRole(Enum.Role.Admin)]
public class SaveFranchiseRecords
{
    public class Handler(IFranchiseRepository franchiseRepository)
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Franchise franchise = await franchiseRepository.Get(command.FranchiseId);

            if (franchise is null)
                return;

            foreach (CareerFranchiseRecordEditModel careerFranchiseRecord in command.CareerFranchiseRecords)
            {
                if (careerFranchiseRecord.RecordTypeId == 0 || careerFranchiseRecord.GetPersonId() == 0)
                    continue;

                franchise.SetCareerFranchiseRecord(
                    careerFranchiseRecord.Id,
                    careerFranchiseRecord.Person?.Id > 0 ? careerFranchiseRecord.Person.Id : careerFranchiseRecord.PersonId,
                    careerFranchiseRecord.RecordTypeId,
                    careerFranchiseRecord.Record
                    );
            }

            franchise.DeleteCareerFranchiseRecords(command.DeletedCareerFranchiseRecordIds);

            foreach (SingleSeasonFranchiseRecordEditModel singleSeasonFranchiseRecord in command.SingleSeasonFranchiseRecords)
            {
                if (singleSeasonFranchiseRecord.RecordTypeId == 0 || singleSeasonFranchiseRecord.GetPersonId() == 0)
                    continue;

                franchise.SetSingleSeasonFranchiseRecord(
                    singleSeasonFranchiseRecord.Id,
                    singleSeasonFranchiseRecord.Person?.Id > 0 ? singleSeasonFranchiseRecord.Person.Id : singleSeasonFranchiseRecord.PersonId,
                    singleSeasonFranchiseRecord.RecordTypeId,
                    singleSeasonFranchiseRecord.Record,
                    singleSeasonFranchiseRecord.Year ?? 0);
            }

            franchise.DeleteSingleSeasonFranchiseRecords(command.DeletedSingleSeasonFranchiseRecordIds);

            await franchiseRepository.Update(franchise);
        }
    }

    public class Command(FranchiseRecordEditModel editModel)
        : DomainCommand, ICommand
    {
        public List<CareerFranchiseRecordEditModel> CareerFranchiseRecords
            => editModel.CareerFranchiseRecords
                        .Where(x => !x.IsDeleted)
                        .ToList();

        public int[] DeletedCareerFranchiseRecordIds
            => editModel.CareerFranchiseRecords
                        .Where(x => x.Id > 0 && x.IsDeleted)
                        .Select(x => x.Id)
                        .ToArray();

        public int[] DeletedSingleSeasonFranchiseRecordIds
            => editModel.SingleSeasonFranchiseRecords
                        .Where(x => x.Id > 0 && x.IsDeleted)
                        .Select(x => x.Id)
                        .ToArray();

        public int FranchiseId
            => editModel.Franchise?.Id ?? 0;

        public List<SingleSeasonFranchiseRecordEditModel> SingleSeasonFranchiseRecords
            => editModel.SingleSeasonFranchiseRecords
                        .Where(x => !x.IsDeleted)
                        .ToList();
    }
}
