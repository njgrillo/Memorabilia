namespace Memorabilia.Application.Features.Admin.Management.AllStars;

[AuthorizeByRole(Enum.Role.Admin)]
public class SaveAllStarManagement
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IAllStarDetailRepository _allStarDetailRepository;

        public Handler(IAllStarDetailRepository allStarDetailRepository)
        {
            _allStarDetailRepository = allStarDetailRepository;
        }

        protected override async Task Handle(Command command)
        {
            Entity.AllStarDetail allStarDetail;

            if (command.IsNew)
            {
                allStarDetail = new Entity.AllStarDetail(command.SportLeagueLevelId,
                                                         command.Year,
                                                         command.NumberOfAllStars,
                                                         command.MonthPlayed);

                await _allStarDetailRepository.Add(allStarDetail);

                return;
            }

            allStarDetail = await _allStarDetailRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _allStarDetailRepository.Delete(allStarDetail);
                return;
            }

            allStarDetail.Set(command.NumberOfAllStars, command.MonthPlayed);

            await _allStarDetailRepository.Update(allStarDetail);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly AllStarManagementEditModel _editModel;

        public Command(AllStarManagementEditModel editModel)
        {
            _editModel = editModel;
        }

        public int Id
            => _editModel.Id;

        public bool IsDeleted
            => _editModel.IsDeleted;

        public bool IsNew 
            => _editModel.IsNew;

        public int MonthPlayed
            => _editModel.MonthPlayed ?? 0;

        public int NumberOfAllStars
            => _editModel.NumberOfAllStars ?? 0;

        public int SportLeagueLevelId
            => _editModel.SportLeagueLevelId;

        public int Year
            => _editModel.Year ?? 0;
    }
}
