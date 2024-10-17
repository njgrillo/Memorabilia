namespace Memorabilia.Application.Features.Admin.Sports.Management.Accomplishments.Records;

[AuthorizeByRole(Enum.Role.Admin)]
public class SaveSportRecords
{
    public class Handler(IPersonRepository personRepository)
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            if (command.PersonIds.Length == 0)
                return;

            Entity.Person[] persons = await personRepository.GetAll(command.PersonIds);

            await UpdateCareerRecords(command, persons);
            await UpdateSingleSeasonRecords(command, persons);
        }

        private async Task UpdateCareerRecords(Command command, Entity.Person[] persons)
        {
            foreach (CareerRecordEditModel careerRecord in command.CareerRecords)
            {
                if (careerRecord.RecordTypeId == 0 || careerRecord.GetPersonId() == 0)
                    continue;

                Entity.Person person = persons.Single(x => x.Id == careerRecord.GetPersonId());

                if (careerRecord.Id > 0 && careerRecord.IsDeleted)
                {
                    person.RemoveCareerRecords(careerRecord.Id);
                }
                else
                {
                    person.SetCareerRecord(careerRecord.Id, careerRecord.RecordTypeId, careerRecord.Record);
                }

                await personRepository.Update(person);
            }
        }

        private async Task UpdateSingleSeasonRecords(Command command, Entity.Person[] persons)
        {
            foreach (SingleSeasonRecordEditModel singleSeasonRecord in command.SingleSeasonRecords)
            {
                if (singleSeasonRecord.RecordTypeId == 0 || singleSeasonRecord.GetPersonId() == 0)
                    continue;

                Entity.Person person = persons.Single(x => x.Id == singleSeasonRecord.GetPersonId());

                if (singleSeasonRecord.Id > 0 && singleSeasonRecord.IsDeleted)
                {
                    person.RemoveSingleSeasonRecords(singleSeasonRecord.Id);
                }
                else
                {
                    person.SetSingleSeasonRecord(
                        singleSeasonRecord.Id, 
                        singleSeasonRecord.RecordTypeId,                         
                        singleSeasonRecord.Year ?? 0,
                        singleSeasonRecord.Record
                        );
                }

                await personRepository.Update(person);
            }
        }
    }

    public class Command(SportRecordsEditModel editModel)
        : DomainCommand, ICommand
    {
        public List<CareerRecordEditModel> CareerRecords
            => editModel.CareerRecords
                        .ToList();

        public int[] PersonIds
            => editModel.CareerRecords
                        .Select(x => x.GetPersonId())
                        .Union(editModel.SingleSeasonRecords.Select(x => x.GetPersonId()))
                        .Distinct()
                        .ToArray();

        public List<SingleSeasonRecordEditModel> SingleSeasonRecords
            => editModel.SingleSeasonRecords
                        .ToList();
    }
}
