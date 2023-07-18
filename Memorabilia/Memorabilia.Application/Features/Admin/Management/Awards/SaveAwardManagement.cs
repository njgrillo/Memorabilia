namespace Memorabilia.Application.Features.Admin.Management.Awards;

public record SaveAwardManagement(AwardManagementEditModel AwardManagement) : ICommand
{
    public class Handler : CommandHandler<SaveAwardManagement>
    {
        private readonly IAwardDetailRepository _awardDetailRepository;

        public Handler(IAwardDetailRepository awardDetailRepository)
        {
            _awardDetailRepository = awardDetailRepository;
        }

        protected override async Task Handle(SaveAwardManagement request)
        {
            Entity.AwardDetail awardDetail;

            if (request.AwardManagement.IsNew)
            {
                awardDetail = new Entity.AwardDetail(request.AwardManagement.AwardType.Id,
                                                     request.AwardManagement.BeginYear ?? 0,
                                                     request.AwardManagement.EndYear,
                                                     request.AwardManagement.NumberOfWinners,
                                                     request.AwardManagement.MonthAwarded);

                await _awardDetailRepository.Add(awardDetail);

                return;
            }

            awardDetail = await _awardDetailRepository.Get(request.AwardManagement.AwardType.Id);

            if (request.AwardManagement.IsDeleted)
            {
                await _awardDetailRepository.Delete(awardDetail);

                return;
            }

            awardDetail.Set(request.AwardManagement.BeginYear ?? 0,
                            request.AwardManagement.EndYear,
                            request.AwardManagement.NumberOfWinners,
                            request.AwardManagement.MonthAwarded);

            await _awardDetailRepository.Update(awardDetail);
        }
    }
}
