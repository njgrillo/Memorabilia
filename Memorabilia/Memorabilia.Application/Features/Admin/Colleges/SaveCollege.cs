namespace Memorabilia.Application.Features.Admin.Colleges;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record SaveCollege(DomainEditModel College) : ICommand
{
    public class Handler : CommandHandler<SaveCollege>
    {
        private readonly IDomainRepository<Entity.College> _collegeRepository;

        public Handler(IDomainRepository<Entity.College> collegeRepository)
        {
            _collegeRepository = collegeRepository;
        }

        protected override async Task Handle(SaveCollege request)
        {
            Entity.College college;

            if (request.College.IsNew)
            {
                college = new Entity.College(request.College.Name,
                                             request.College.Abbreviation);

                await _collegeRepository.Add(college);

                return;
            }

            college = await _collegeRepository.Get(request.College.Id);

            if (request.College.IsDeleted)
            {
                await _collegeRepository.Delete(college);

                return;
            }

            college.Set(request.College.Name, 
                        request.College.Abbreviation);

            await _collegeRepository.Update(college);
        }
    }
}
