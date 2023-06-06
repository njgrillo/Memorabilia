using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Colleges;

public record SaveCollege(DomainEditModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveCollege>
    {
        private readonly IDomainRepository<College> _collegeRepository;

        public Handler(IDomainRepository<College> collegeRepository)
        {
            _collegeRepository = collegeRepository;
        }

        protected override async Task Handle(SaveCollege request)
        {
            College college;

            if (request.ViewModel.IsNew)
            {
                college = new College(request.ViewModel.Name, request.ViewModel.Abbreviation);

                await _collegeRepository.Add(college);

                return;
            }

            college = await _collegeRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _collegeRepository.Delete(college);

                return;
            }

            college.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _collegeRepository.Update(college);
        }
    }
}
