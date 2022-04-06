using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.People
{
    public class SavePersonHallOfFame
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IPersonRepository _personRepository;

            public Handler(IPersonRepository personRepository)
            {
                _personRepository = personRepository;
            }

            protected override async Task Handle(Command command)
            {
                var person = await _personRepository.Get(command.PersonId).ConfigureAwait(false);

                if (command.DeletedHallOfFameIds.Any())
                    person.RemoveHallOfFames(command.DeletedHallOfFameIds);

                foreach (var hallOfFame in command.HallOfFames.Where(hof => !hof.IsDeleted))
                {
                    person.SetHallOfFame(hallOfFame.SportLeagueLevelId, 
                                         hallOfFame.FranchiseId > 0 ? hallOfFame.FranchiseId : null, 
                                         hallOfFame.InductionYear, 
                                         hallOfFame.VotePercentage);
                }

                await _personRepository.Update(person).ConfigureAwait(false);
            }
        }

        public class Command : DomainCommand, ICommand
        {
            public Command(int personId, IEnumerable<SavePersonHallOfFameViewModel> hallOfFames)
            {
                PersonId = personId;
                HallOfFames = hallOfFames.ToArray();
            }

            public int[] DeletedHallOfFameIds => HallOfFames.Where(hof => hof.IsDeleted).Select(hof => hof.Id).ToArray();

            public SavePersonHallOfFameViewModel[] HallOfFames { get; }

            public int PersonId { get; }
        }
    }
}
