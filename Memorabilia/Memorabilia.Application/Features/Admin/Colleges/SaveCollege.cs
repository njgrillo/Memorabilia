using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Colleges
{
    public class SaveCollege
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly ICollegeRepository _collegeRepository;

            public Handler(ICollegeRepository collegeRepository)
            {
                _collegeRepository = collegeRepository;
            }

            protected override async Task Handle(Command command)
            {
                College college;

                if (command.IsNew)
                {
                    college = new College(command.Name, command.Abbreviation);
                    await _collegeRepository.Add(college).ConfigureAwait(false);

                    return;
                }

                college = await _collegeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _collegeRepository.Delete(college).ConfigureAwait(false);

                    return;
                }

                college.Set(command.Name, command.Abbreviation);

                await _collegeRepository.Update(college).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
        }
    }
}
