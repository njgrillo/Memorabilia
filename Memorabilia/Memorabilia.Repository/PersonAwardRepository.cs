using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class PersonAwardRepository : BaseRepository<PersonAward>, IPersonAwardRepository
    {
        private readonly DomainContext _context;

        public PersonAwardRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<PersonAward> PersonAward => _context.Set<PersonAward>()
                                                               .Include(personAward => personAward.Person);

        public async Task<IEnumerable<PersonAward>> GetAll(int awardTypeId)
        {
            return (await PersonAward.Where(personAward => personAward.AwardTypeId == awardTypeId)
                                     .ToListAsync()
                                     .ConfigureAwait(false)).OrderByDescending(personAward => personAward.Year)
                                                            .ThenBy(personAward => personAward.Person.DisplayName);
        }
    }
}
