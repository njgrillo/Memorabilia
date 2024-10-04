namespace Memorabilia.Application.Features.Tools.Shared.CareerFranchiseRecords;

public record GetCareerFranchiseRecords(Constant.Franchise Franchise) 
    : IQuery<Entity.CareerFranchiseRecord[]>
{
    public class Handler(ICareerFranchiseRecordRepository careerFranchiseRecordRepository)
        : QueryHandler<GetCareerFranchiseRecords, Entity.CareerFranchiseRecord[]>
    {
        protected override async Task<Entity.CareerFranchiseRecord[]> Handle(GetCareerFranchiseRecords query)
            => (await careerFranchiseRecordRepository.GetAllByFranchise(query.Franchise.Id))
                    .ToArray();
    }
}
