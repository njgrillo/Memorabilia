using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class PersonAccomplishmentRepository : BaseRepository<PersonAccomplishment>, IPersonAccomplishmentRepository
    {
        private readonly DomainContext _context;

        public PersonAccomplishmentRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<PersonAccomplishment> PersonAccomplishment => _context.Set<PersonAccomplishment>()
                                                                                 .Include(personAccomplishment => personAccomplishment.Person);

        public async Task<IEnumerable<PersonAccomplishment>> GetAll(int accomplishmentTypeId)
        {
            var accomplishments = await PersonAccomplishment.Where(personAccomplishment => personAccomplishment.AccomplishmentTypeId == accomplishmentTypeId)
                                                            .ToListAsync()
                                                            .ConfigureAwait(false);

            var sortByDate = accomplishments.Any(personAccomplishment => personAccomplishment.Date.HasValue);

            return sortByDate ? accomplishments.OrderByDescending(personAccomplishment => personAccomplishment.Date)
                                               .ThenBy(personAccomplishment => personAccomplishment.Person.DisplayName)
                              : accomplishments.OrderByDescending(personAccomplishment => personAccomplishment.Year)
                                               .ThenBy(personAccomplishment => personAccomplishment.Person.DisplayName);
        }
    }
}
