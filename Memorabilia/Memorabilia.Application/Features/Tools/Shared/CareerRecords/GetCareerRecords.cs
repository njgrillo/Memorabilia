namespace Memorabilia.Application.Features.Tools.Shared.CareerRecords;

public record GetCareerRecords(Constant.Sport Sport) : IQuery<Entity.CareerRecord[]>
{
    public class Handler(ICareerRecordRepository careerRecordRepository) 
        : QueryHandler<GetCareerRecords, Entity.CareerRecord[]>
    {
        protected override async Task<Entity.CareerRecord[]> Handle(GetCareerRecords query)
            => (await careerRecordRepository.GetAll(query.Sport.Id))
                    .ToArray();
    }
}
