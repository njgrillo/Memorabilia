namespace Memorabilia.Application.Features.Admin.Management.Accomplishments;

[AuthorizeByRole(Enum.Role.Admin)]
public class SaveAccomplishmentManagement
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IAccomplishmentDetailRepository _accomplishmentDetailRepository;

        public Handler(IAccomplishmentDetailRepository accomplishmentDetailRepository)
        {
            _accomplishmentDetailRepository = accomplishmentDetailRepository;
        }

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

                await _accomplishmentDetailRepository.Add(accomplishmentDetail);

                return;
            }

            accomplishmentDetail = await _accomplishmentDetailRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _accomplishmentDetailRepository.Delete(accomplishmentDetail);
                return;
            }

            accomplishmentDetail.Set(command.BeginYear,
                                     command.EndYear,
                                     command.Year,
                                     command.NumberOfWinners,
                                     command.MonthAccomplished);

            await _accomplishmentDetailRepository.Update(accomplishmentDetail);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly AccomplishmentManagementEditModel _editModel;

        public Command(AccomplishmentManagementEditModel editModel)
        {
            _editModel = editModel;
        }

        public int AccomplishmentTypeId
            => _editModel.AccomplishmentType.Id;

        public int? BeginYear
            => _editModel.BeginYear;

        public int? EndYear
            => _editModel.EndYear;

        public int Id
            => _editModel.Id;

        public bool IsDeleted
            => _editModel.IsDeleted;

        public bool IsNew
            => _editModel.IsNew;

        public int? MonthAccomplished
            => _editModel.MonthAccomplished;

        public int NumberOfWinners
            => _editModel.NumberOfWinners ?? 0;

        public int? Year
            => _editModel.Year;
    }
}
