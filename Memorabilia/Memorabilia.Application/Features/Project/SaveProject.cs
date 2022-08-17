using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Project
{
    public class SaveProject
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IProjectRepository _projectRepository;

            public Handler(IProjectRepository projectRepository)
            {
                _projectRepository = projectRepository;
            }

            protected override async Task Handle(Command command)
            {
                Domain.Entities.Project project;

                if (command.IsNew)
                {
                    project = new Domain.Entities.Project(command.Name, 
                                                          command.StartDate,
                                                          command.EndDate,
                                                          command.UserId);

                    AddProjectPeople(project, command);

                    await _projectRepository.Add(project).ConfigureAwait(false);

                    command.Id = project.Id;

                    return;
                }

                project = await _projectRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _projectRepository.Delete(project).ConfigureAwait(false);

                    return;
                }

                project.Set(command.Name,
                            command.StartDate,
                            command.EndDate);

                AddProjectPeople(project, command);
                DeleteProjectPeople(project, command);

                await _projectRepository.Update(project).ConfigureAwait(false);
            }

            private static void AddProjectPeople(Domain.Entities.Project project, Command command)
            {
                foreach (var projectPerson in command.People.Where(person => !person.IsDeleted))
                {
                    project.SetPerson(projectPerson.Id,
                                      projectPerson.Person.Id,
                                      projectPerson.ItemTypeId,
                                      projectPerson.Upgrade,
                                      projectPerson.Rank,
                                      projectPerson.PriorityTypeId);
                }
            }

            private static void DeleteProjectPeople(Domain.Entities.Project project, Command command)
            {
                if (!command.DeletePeopleIds.Any())
                    return;

                project.RemovePeople(command.DeletePeopleIds);
            }
        }

        public class Command : DomainCommand, ICommand
        {
            private readonly SaveProjectViewModel _viewModel;

            public Command(SaveProjectViewModel viewModel)
            {
                _viewModel = viewModel;
                Id = _viewModel.Id;
            }

            public int[] DeletePeopleIds => _viewModel.People.Where(person => person.IsDeleted).Select(person => person.Id).ToArray();

            public DateTime? EndDate => _viewModel.EndDate;

            public int Id { get; set; }

            public bool IsDeleted => _viewModel.IsDeleted;

            public bool IsModified => _viewModel.IsModified;

            public bool IsNew => _viewModel.IsNew;

            public string Name => _viewModel.Name;

            public List<SaveProjectPersonViewModel> People => _viewModel.People;

            public DateTime? StartDate => _viewModel.StartDate;

            public int UserId => _viewModel.UserId;
        }
    }
}
