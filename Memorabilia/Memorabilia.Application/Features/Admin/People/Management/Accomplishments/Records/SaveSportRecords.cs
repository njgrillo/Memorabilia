namespace Memorabilia.Application.Features.Admin.People.Management.Accomplishments.Records;

[AuthorizeByRole(Enum.Role.Admin)]
public class SaveSportRecords
{
    public class Handler(ICareerRecordRepository careerRecordRepository, ISingleSeasonRecordRepository singleSeasonRecordRepository)
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            await UpdateCareerRecords(command);
            await UpdateSingleSeasonRecords(command);
        }

        private async Task UpdateCareerRecords(Command command)
        {
            Entity.CareerRecord[] careerRecords = (await careerRecordRepository.GetAll(command.SportId)).ToArray();

            foreach (CareerRecordEditModel careerRecord in command.CareerRecords.Where(x => x.IsNew))
            {
                await careerRecordRepository.Add(
                    new Entity.CareerRecord(
                        careerRecord.Person.Id > 0 ? careerRecord.Person.Id : careerRecord.PersonId,
                        careerRecord.RecordTypeId,
                        careerRecord.Record)
                    );
            }

            foreach (CareerRecordEditModel careerRecord in command.CareerRecords.Where(x => x.IsModified))
            {
                Entity.CareerRecord record = careerRecords.Single(x => x.Id == careerRecord.Id);

                record.SetByPerson(
                    careerRecord.Person.Id > 0 ? careerRecord.Person.Id : careerRecord.PersonId,
                    careerRecord.Record
                    );
            }

            foreach (CareerRecordEditModel careerRecord in command.CareerRecords.Where(x => x.IsDeleted))
            {
                await careerRecordRepository.Delete(careerRecords.Single(x => x.Id == careerRecord.Id));
            }
        }

        private async Task UpdateSingleSeasonRecords(Command command)
        {
            Entity.SingleSeasonRecord[] singleSeasonRecords = (await singleSeasonRecordRepository.GetAll(command.SportId)).ToArray();

            foreach (SingleSeasonRecordEditModel singleSeasonRecord in command.SingleSeasonRecords.Where(x => x.IsNew))
            {
                await singleSeasonRecordRepository.Add(
                    new Entity.SingleSeasonRecord(
                        singleSeasonRecord.Person.Id > 0 ? singleSeasonRecord.Person.Id : singleSeasonRecord.PersonId,
                        singleSeasonRecord.RecordTypeId,                        
                        singleSeasonRecord.Year ?? 0,
                        singleSeasonRecord.Record)
                    );
            }

            foreach (SingleSeasonRecordEditModel singleSeasonRecord in command.SingleSeasonRecords.Where(x => x.IsModified))
            {
                Entity.SingleSeasonRecord record = singleSeasonRecords.Single(x => x.Id == singleSeasonRecord.Id);

                record.SetByPerson(
                    singleSeasonRecord.Person.Id > 0 ? singleSeasonRecord.Person.Id : singleSeasonRecord.PersonId,
                    singleSeasonRecord.Year ?? 0,
                    singleSeasonRecord.Record
                    );
            }

            foreach (SingleSeasonRecordEditModel singleSeasonRecord in command.SingleSeasonRecords.Where(x => x.IsDeleted))
            {
                await singleSeasonRecordRepository.Delete(singleSeasonRecords.Single(x => x.Id == singleSeasonRecord.Id));
            }
        }
    }

    public class Command(SportRecordsEditModel editModel)
        : DomainCommand, ICommand
    {
        public List<CareerRecordEditModel> CareerRecords
            => editModel.CareerRecords
                        .Where(x => !x.IsDeleted)
                        .ToList();

        public int[] DeletedCareerRecordIds
            => editModel.CareerRecords
                        .Where(x => x.Id > 0 && x.IsDeleted)
                        .Select(x => x.Id)
                        .ToArray();

        public int[] DeletedSingleSeasonRecordIds
            => editModel.SingleSeasonRecords
                        .Where(x => x.Id > 0 && x.IsDeleted)
                        .Select(x => x.Id)
                        .ToArray();

        public int SportId
            => editModel.SportId;

        public List<SingleSeasonRecordEditModel> SingleSeasonRecords
            => editModel.SingleSeasonRecords
                        .Where(x => !x.IsDeleted)
                        .ToList();
    }
}
