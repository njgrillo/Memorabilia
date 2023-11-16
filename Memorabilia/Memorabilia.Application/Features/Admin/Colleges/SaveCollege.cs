namespace Memorabilia.Application.Features.Admin.Colleges;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveCollege(DomainEditModel College) : ICommand
{
    public class Handler(IDomainRepository<Entity.College> collegeRepository) 
        : CommandHandler<SaveCollege>
    {
        protected override async Task Handle(SaveCollege request)
        {
            Entity.College college;

            if (request.College.IsNew)
            {
                college = new Entity.College(request.College.Name,
                                             request.College.Abbreviation);

                await collegeRepository.Add(college);

                return;
            }

            college = await collegeRepository.Get(request.College.Id);

            if (request.College.IsDeleted)
            {
                await collegeRepository.Delete(college);

                return;
            }

            college.Set(request.College.Name, 
                        request.College.Abbreviation);

            await collegeRepository.Update(college);
        }
    }
}
