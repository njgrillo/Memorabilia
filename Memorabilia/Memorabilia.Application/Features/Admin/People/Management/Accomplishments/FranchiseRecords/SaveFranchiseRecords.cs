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

            Dictionary<int, List<CareerFranchiseRecordEditModel>> careerFranchiseRecordTypes
                = command.CareerFranchiseRecords
                         .GroupBy(x => x.RecordTypeId)
                         .ToDictionary(g => g.Key, g => g.ToList());

            foreach (KeyValuePair<int, List<CareerFranchiseRecordEditModel>> careerFranchiseRecordType in careerFranchiseRecordTypes)
            {
                if (careerFranchiseRecordType.Key == 0)
                    continue;

                string record = careerFranchiseRecordType.Value.First().Record;
                int[] personIds = careerFranchiseRecordType.Value.Where(x => x.Person.Id > 0).Select(x => x.Person.Id).ToArray();

                franchise.SetCareerFranchiseRecord(careerFranchiseRecordType.Key, record, personIds);
            }

            franchise.DeleteCareerFranchiseRecords(command.DeletedCareerFranchiseRecordIds);

            Dictionary<int, List<SingleSeasonFranchiseRecordEditModel>> singleSeasonFranchiseRecordTypes
                = command.SingleSeasonFranchiseRecords
                         .GroupBy(x => x.RecordTypeId)
                         .ToDictionary(g => g.Key, g => g.ToList());

            foreach (KeyValuePair<int, List<SingleSeasonFranchiseRecordEditModel>> singleSeasonFranchiseRecordType in singleSeasonFranchiseRecordTypes)
            {
                if (singleSeasonFranchiseRecordType.Key == 0)
                    continue;

                string record = singleSeasonFranchiseRecordType.Value.First().Record;

                Tuple<int, int>[] personYears
                    = singleSeasonFranchiseRecordType.Value
                                                     .Where(x => x.Person.Id > 0)
                                                     .Select(x => new Tuple<int, int>(x.Person.Id, x.Year ?? 0))
                                                     .ToArray();

                franchise.SetSingleSeasonFranchiseRecord(singleSeasonFranchiseRecordType.Key, record, personYears);
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
