namespace Memorabilia.Application.Features.Admin.Management.Awards;

[AuthorizeByRole(Enum.Role.Admin)]
public class SaveAwardManagement
{
    public class Handler(IAwardDetailRepository awardDetailRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.AwardDetail awardDetail;

            if (command.AwardManagement.IsNew)
            {
                awardDetail = new Entity.AwardDetail(command.AwardManagement.AwardType.Id,
                                                     command.AwardManagement.BeginYear ?? 0,
                                                     command.AwardManagement.EndYear,
                                                     command.AwardManagement.NumberOfWinners,
                                                     command.AwardManagement.MonthAwarded);

                foreach (AwardExclusionYearEditModel exclusionYear in command.AwardManagement.ExclusionYears.Where(item => !item.IsDeleted))
                {
                    awardDetail.SetExclusionYear(exclusionYear.Id, exclusionYear.Year, exclusionYear.Reason);
                }

                await awardDetailRepository.Add(awardDetail);

                return;
            }

            awardDetail = await awardDetailRepository.Get(command.AwardManagement.AwardType.Id);

            if (command.AwardManagement.IsDeleted)
            {
                await awardDetailRepository.Delete(awardDetail);
                return;
            }

            awardDetail.Set(command.AwardManagement.BeginYear ?? 0,
                            command.AwardManagement.EndYear,
                            command.AwardManagement.NumberOfWinners,
                            command.AwardManagement.MonthAwarded);

            awardDetail.RemoveExclusionYears(command.DeletedExclusionYearsIds);

            foreach (AwardExclusionYearEditModel exclusionYear in command.AwardManagement.ExclusionYears.Where(item => !item.IsDeleted))
            {
                awardDetail.SetExclusionYear(exclusionYear.Id, exclusionYear.Year, exclusionYear.Reason);
            }

            await awardDetailRepository.Update(awardDetail);
        }
    }

    public class Command(AwardManagementEditModel editModel) 
        : DomainCommand, ICommand
    {
        public AwardManagementEditModel AwardManagement
            => editModel;

        public int[] DeletedExclusionYearsIds
            => editModel.ExclusionYears
                         .Where(exclusionYear => exclusionYear.IsDeleted)
                         .Select(exclusionYear => exclusionYear.Id)
                         .ToArray();
    }
}
