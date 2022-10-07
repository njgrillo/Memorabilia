using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Colleges;

public class SaveCollege
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<College> _collegeRepository;

        public Handler(IDomainRepository<College> collegeRepository)
        {
            _collegeRepository = collegeRepository;
        }

        protected override async Task Handle(Command command)
        {
            College college;

            if (command.IsNew)
            {
                college = new College(command.Name, command.Abbreviation);

                await _collegeRepository.Add(college);

                return;
            }

            college = await _collegeRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _collegeRepository.Delete(college);

                return;
            }

            college.Set(command.Name, command.Abbreviation);

            await _collegeRepository.Update(college);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
