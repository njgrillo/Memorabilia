namespace Memorabilia.Application.Features.Admin.Management.Awards;

public class SaveAwardManagement
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IAwardDetailRepository _awardDetailRepository;

        public Handler(IAwardDetailRepository awardDetailRepository)
        {
            _awardDetailRepository = awardDetailRepository;
        }

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
                    awardDetail.SetExclusionYear(exclusionYear.Year, exclusionYear.Reason);
                }

                await _awardDetailRepository.Add(awardDetail);

                return;
            }

            awardDetail = await _awardDetailRepository.Get(command.AwardManagement.AwardType.Id);

            if (command.AwardManagement.IsDeleted)
            {
                await _awardDetailRepository.Delete(awardDetail);
                return;
            }

            awardDetail.Set(command.AwardManagement.BeginYear ?? 0,
                            command.AwardManagement.EndYear,
                            command.AwardManagement.NumberOfWinners,
                            command.AwardManagement.MonthAwarded);

            awardDetail.RemoveExclusionYears(command.DeletedExclusionYearsIds);

            foreach (AwardExclusionYearEditModel exclusionYear in command.AwardManagement.ExclusionYears.Where(item => !item.IsDeleted))
            {
                awardDetail.SetExclusionYear(exclusionYear.Year, exclusionYear.Reason);
            }

            await _awardDetailRepository.Update(awardDetail);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly AwardManagementEditModel _editModel;

        public Command(AwardManagementEditModel editModel)
        {
            _editModel = editModel;
        }

        public AwardManagementEditModel AwardManagement
            => _editModel;

        public int[] DeletedExclusionYearsIds
            => _editModel.ExclusionYears
                         .Where(exclusionYear => exclusionYear.IsDeleted)
                         .Select(exclusionYear => exclusionYear.Id)
                         .ToArray();
    }
}
