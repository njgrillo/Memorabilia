using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        private readonly MemorabiliaContext _context;

        public ProjectRepository(MemorabiliaContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Project> Project => _context.Set<Project>()
                                                       .Include(project => project.People);

        public async Task Add(Project project, CancellationToken cancellationToken = default)
        {
            _context.Add(project);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Project project, CancellationToken cancellationToken = default)
        {
            _context.Set<Project>().Remove(project);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Project> Get(int id)
        {
            return await Project.SingleOrDefaultAsync(project => project.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Project>> GetAll(int userId)
        {
            return (await Project.Where(project => project.UserId == userId)
                                 .ToListAsync()
                                 .ConfigureAwait(false)).OrderBy(project => project.Name);
        }

        public async Task Update(Project project, CancellationToken cancellationToken = default)
        {
            _context.Set<Project>().Update(project);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
