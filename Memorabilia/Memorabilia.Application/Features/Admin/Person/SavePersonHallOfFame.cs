using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Person
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

                foreach (var hallOfFame in command.HallOfFames)
                {
                    person.SetHallOfFame(hallOfFame.SportId, 
                                         hallOfFame.LevelTypeId, 
                                         hallOfFame.FranchiseId > 0 ? hallOfFame.FranchiseId : null, 
                                         hallOfFame.InductionYear, 
                                         hallOfFame.VoteCount);
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

            public SavePersonHallOfFameViewModel[] HallOfFames { get; }

            public int PersonId { get; }
        }
    }
}
