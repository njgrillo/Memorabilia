namespace Memorabilia.Application.Features.Admin.Management.Accomplishments;

[AuthorizeByRole(Enum.Role.Admin)]
public class SaveAccomplishmentManagement
{
    public class Handler(IAccomplishmentDetailRepository accomplishmentDetailRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.AccomplishmentDetail accomplishmentDetail;

            if (command.IsNew)
            {
                accomplishmentDetail = new Entity.AccomplishmentDetail(command.Id,
                                                                       command.BeginYear,
                                                                       command.EndYear,
                                                                       command.Year,
                                                                       command.NumberOfWinners,
                                                                       command.MonthAccomplished);

                await accomplishmentDetailRepository.Add(accomplishmentDetail);

                return;
            }

            accomplishmentDetail = await accomplishmentDetailRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await accomplishmentDetailRepository.Delete(accomplishmentDetail);
                return;
            }

            accomplishmentDetail.Set(command.BeginYear,
                                     command.EndYear,
                                     command.Year,
                                     command.NumberOfWinners,
                                     command.MonthAccomplished);

            await accomplishmentDetailRepository.Update(accomplishmentDetail);
        }
    }

    public class Command(AccomplishmentManagementEditModel editModel) 
        : DomainCommand, ICommand
    {
        public int AccomplishmentTypeId
            => editModel.AccomplishmentType.Id;

        public int? BeginYear
            => editModel.BeginYear;

        public int? EndYear
            => editModel.EndYear;

        public int Id
            => editModel.Id;

        public bool IsDeleted
            => editModel.IsDeleted;

        public bool IsNew
            => editModel.IsNew;

        public int? MonthAccomplished
            => editModel.MonthAccomplished;

        public int NumberOfWinners
            => editModel.NumberOfWinners ?? 0;

        public int? Year
            => editModel.Year;
    }
}
