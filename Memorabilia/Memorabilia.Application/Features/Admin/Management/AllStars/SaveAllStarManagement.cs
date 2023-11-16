namespace Memorabilia.Application.Features.Admin.Management.AllStars;

[AuthorizeByRole(Enum.Role.Admin)]
public class SaveAllStarManagement
{
    public class Handler(IAllStarDetailRepository allStarDetailRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.AllStarDetail allStarDetail;

            if (command.IsNew)
            {
                allStarDetail = new Entity.AllStarDetail(command.SportLeagueLevelId,
                                                         command.Year,
                                                         command.NumberOfAllStars,
                                                         command.MonthPlayed);

                await allStarDetailRepository.Add(allStarDetail);

                return;
            }

            allStarDetail = await allStarDetailRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await allStarDetailRepository.Delete(allStarDetail);
                return;
            }

            allStarDetail.Set(command.NumberOfAllStars, command.MonthPlayed);

            await allStarDetailRepository.Update(allStarDetail);
        }
    }

    public class Command(AllStarManagementEditModel editModel) 
        : DomainCommand, ICommand
    {
        public int Id
            => editModel.Id;

        public bool IsDeleted
            => editModel.IsDeleted;

        public bool IsNew 
            => editModel.IsNew;

        public int MonthPlayed
            => editModel.MonthPlayed ?? 0;

        public int NumberOfAllStars
            => editModel.NumberOfAllStars ?? 0;

        public int SportLeagueLevelId
            => editModel.SportLeagueLevelId;

        public int Year
            => editModel.Year ?? 0;
    }
}
