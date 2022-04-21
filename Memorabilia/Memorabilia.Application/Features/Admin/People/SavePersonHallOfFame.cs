﻿using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
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

                UpdateFranchiseHallOfFames(command, person);
                UpdateHallOfFames(command, person);

                await _personRepository.Update(person).ConfigureAwait(false);
            }

            private static void UpdateFranchiseHallOfFames(Command command, Person person)
            {
                person.RemoveFranchiseHallOfFames(command.DeletedFranchiseHallOfFameIds);

                foreach (var hallOfFame in command.FranchiseHallOfFames.Where(hof => !hof.IsDeleted))
                {
                    person.SetFranchiseHallOfFame(hallOfFame.FranchiseId, hallOfFame.Year);
                }
            }

            private static void UpdateHallOfFames(Command command, Person person)
            {
                person.RemoveHallOfFames(command.DeletedHallOfFameIds);

                foreach (var hallOfFame in command.HallOfFames.Where(hof => !hof.IsDeleted))
                {
                    person.SetHallOfFame(hallOfFame.SportLeagueLevelId,
                                         hallOfFame.InductionYear,
                                         hallOfFame.VotePercentage,
                                         hallOfFame.BallotNumber > 0 ? hallOfFame.BallotNumber : null);
                }
            }
        }

        public class Command : DomainCommand, ICommand
        {
            private readonly SavePersonHallOfFamesViewModel _viewModel;

            public Command(int personId, SavePersonHallOfFamesViewModel viewModel)
            {               
                PersonId = personId;
                _viewModel = viewModel;
            }

            public int[] DeletedFranchiseHallOfFameIds => _viewModel.FranchiseHallOfFames.Where(hof => hof.IsDeleted).Select(hof => hof.Id).ToArray();

            public int[] DeletedHallOfFameIds => _viewModel.HallOfFames.Where(hof => hof.IsDeleted).Select(hof => hof.Id).ToArray();

            public SavePersonFranchiseHallOfFameViewModel[] FranchiseHallOfFames => _viewModel.FranchiseHallOfFames.ToArray();

            public SavePersonHallOfFameViewModel[] HallOfFames => _viewModel.HallOfFames.ToArray();

            public int PersonId { get; }
        }
    }
}
