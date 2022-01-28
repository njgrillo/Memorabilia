using Memorabilia.Application.Features.Admin.Commissioner;
using Memorabilia.Application.Features.Admin.ItemTypeBrand;
using Memorabilia.Application.Features.Admin.ItemTypeSize;
using Memorabilia.Application.Features.Admin.Person;
using Memorabilia.Application.Features.Admin.Team;
using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.Baseball
{
    public class BaseballViewModel
    {
        private readonly Domain.Entities.Memorabilia _memorabilia;

        public BaseballViewModel() { }

        public BaseballViewModel(Domain.Entities.Memorabilia memorabilia, 
                                 IEnumerable<ItemTypeBrand> brands, 
                                 IEnumerable<Commissioner> commissioners,
                                 IEnumerable<Person> people,
                                 IEnumerable<ItemTypeSize> sizes,
                                 IEnumerable<Team> teams)
        {
            _memorabilia = memorabilia;
            Brands = brands.Select(brand => new ItemTypeBrandViewModel(brand));
            Commissioners = commissioners.Select(commissioner => new CommissionerViewModel(commissioner));
            People = people.Select(person => new PersonViewModel(person));
            Sizes = sizes.Select(size => new ItemTypeSizeViewModel(size));
            Teams = teams.Select(team => new TeamViewModel(team));
        }

        public IEnumerable<ItemTypeBrandViewModel> Brands = Enumerable.Empty<ItemTypeBrandViewModel>();

        public IEnumerable<CommissionerViewModel> Commissioners = Enumerable.Empty<CommissionerViewModel>();

        public MemorabiliaBaseballType MemorabiliaBaseballType => _memorabilia.BaseballType;

        public MemorabiliaBrand MemorabiliaBrand => _memorabilia.Brand;

        public MemorabiliaCommissioner MemorabiliaCommissioner => _memorabilia.Commissioner;

        public int MemorabiliaId => _memorabilia.Id;

        public MemorabiliaSize MemorabiliaSize => _memorabilia.Size;

        public IEnumerable<MemorabiliaSport> MemorabiliaSports => _memorabilia.Sports;

        public IEnumerable<PersonViewModel> People = Enumerable.Empty<PersonViewModel>();   

        public List<int> PersonIds => _memorabilia.People.Select(person => person.PersonId).ToList();

        public IEnumerable<ItemTypeSizeViewModel> Sizes = Enumerable.Empty<ItemTypeSizeViewModel>();

        public List<int> SportIds => _memorabilia.Sports.Select(sport => sport.SportId).ToList();        

        public List<int> TeamIds => _memorabilia.Teams.Select(team => team.TeamId).ToList();

        public IEnumerable<TeamViewModel> Teams = Enumerable.Empty<TeamViewModel>();
    }
}
