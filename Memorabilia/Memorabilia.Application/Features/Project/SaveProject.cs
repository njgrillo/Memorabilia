using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Project;

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
                                                      command.UserId,
                                                      command.ProjectTypeId);

                SetProjectDetails(command, project);
                SetProjectPeople(project, command);
                SetProjectMemorabiliaTeams(project, command);

                await _projectRepository.Add(project);

                command.Id = project.Id;

                return;
            }

            project = await _projectRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _projectRepository.Delete(project);

                return;
            }

            project.Set(command.Name,
                        command.StartDate,
                        command.EndDate,
                        command.ProjectTypeId);

            SetProjectDetails(command, project);
            SetProjectPeople(project, command);
            SetProjectMemorabiliaTeams(project, command);
            DeleteProjectPeople(project, command);
            DeleteProjectMemorabiliaTeams(project, command);

            await _projectRepository.Update(project);
        }

        private static void DeleteProjectMemorabiliaTeams(Domain.Entities.Project project, Command command)
        {
            if (!command.DeleteMemorabiliaTeamIds.Any())
                return;

            project.RemoveMemorabiliaTeams(command.DeleteMemorabiliaTeamIds);
        }

        private static void DeleteProjectPeople(Domain.Entities.Project project, Command command)
        {
            if (!command.DeletePeopleIds.Any())
                return;

            project.RemovePeople(command.DeletePeopleIds);
        }

        private static void SetProjectDetails(Command command, Domain.Entities.Project project)
        {
            var projectType = Domain.Constants.ProjectType.Find(command.ProjectTypeId);

            if (projectType == Domain.Constants.ProjectType.BaseballType)
            {
                project.SetBaseball(command.Baseball.BaseballTypeId,
                                    command.Baseball.TeamId,
                                    command.Baseball.Year);

                return;
            }

            if (projectType == Domain.Constants.ProjectType.Card)
            {
                project.SetCard(command.Card.BrandId,
                                command.Card.TeamId,
                                command.Card.Year);

                return;
            }

            if (projectType == Domain.Constants.ProjectType.HallOfFame)
            {
                project.SetHallOfFame(command.HallOfFame.SportLeagueLevelId,
                                      command.HallOfFame.Year,
                                      command.HallOfFame.ItemTypeId);

                return;
            }

            if (projectType == Domain.Constants.ProjectType.HelmetType)
            {
                project.SetHelmet(command.Helmet.HelmetTypeId,
                                  command.Helmet.HelmetFinishId,
                                  command.Helmet.SizeId);

                return;
            }

            if (projectType == Domain.Constants.ProjectType.ItemType)
            {
                project.SetItem(command.Item.ItemTypeId,
                                command.Item.MultiSignedItem);

                return;
            }

            if (projectType == Domain.Constants.ProjectType.Team)
            {
                project.SetTeam(command.Team.TeamId, 
                                command.Team.Year);

                return;
            }

            if (projectType == Domain.Constants.ProjectType.WorldSeries)
            {
                project.SetWorldSeries(command.WorldSeries.TeamId,
                                       command.WorldSeries.Year,
                                       command.WorldSeries.ItemTypeId);

                return;
            }
        }

        private static void SetProjectMemorabiliaTeams(Domain.Entities.Project project, Command command)
        {
            foreach (var projectMemorabiliaTeam in command.MemorabiliaTeams.Where(item => !item.IsDeleted))
            {
                project.SetMemorabliaTeam(projectMemorabiliaTeam.Id,
                                          projectMemorabiliaTeam.Team.Id,
                                          projectMemorabiliaTeam.ItemTypeId,
                                          projectMemorabiliaTeam.Upgrade,
                                          projectMemorabiliaTeam.Rank,
                                          projectMemorabiliaTeam.PriorityTypeId,
                                          projectMemorabiliaTeam.ProjectStatusTypeId > 0 ? projectMemorabiliaTeam.ProjectStatusTypeId : null,
                                          projectMemorabiliaTeam.MemorabiliaId > 0 ? projectMemorabiliaTeam.MemorabiliaId : null);
            }
        }

        private static void SetProjectPeople(Domain.Entities.Project project, Command command)
        {
            foreach (var projectPerson in command.People.Where(person => !person.IsDeleted))
            {
                project.SetPerson(projectPerson.Id,
                                  projectPerson.Person.Id,
                                  projectPerson.ItemTypeId,
                                  projectPerson.Upgrade,
                                  projectPerson.Rank,
                                  projectPerson.PriorityTypeId,
                                  projectPerson.ProjectStatusTypeId > 0 ? projectPerson.ProjectStatusTypeId : null,
                                  projectPerson.MemorabiliaId > 0 ? projectPerson.MemorabiliaId : null,
                                  projectPerson.AutographId > 0 ? projectPerson.AutographId : null);
            }
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

        public ProjectBaseball Baseball => _viewModel.Baseball;

        public ProjectCard Card => _viewModel.Card;

        public int[] DeleteMemorabiliaTeamIds 
            => _viewModel.MemorabiliaTeams
                         .Where(item => item.IsDeleted)
                         .Select(item => item.Id)
                         .ToArray();

        public int[] DeletePeopleIds 
            => _viewModel.People
                         .Where(person => person.IsDeleted)
                         .Select(person => person.Id)
                         .ToArray();

        public DateTime? EndDate => _viewModel.EndDate;

        public ProjectHallOfFame HallOfFame => _viewModel.HallOfFame;

        public ProjectHelmet Helmet => _viewModel.Helmet;

        public int Id { get; set; }

        public bool IsDeleted => _viewModel.IsDeleted;

        public bool IsModified => _viewModel.IsModified;

        public bool IsNew => _viewModel.IsNew;

        public ProjectItem Item => _viewModel.Item;

        public List<SaveProjectMemorabiliaTeamViewModel> MemorabiliaTeams => _viewModel.MemorabiliaTeams;

        public string Name => _viewModel.Name;

        public List<SaveProjectPersonViewModel> People => _viewModel.People;

        public DateTime? StartDate => _viewModel.StartDate;

        public int ProjectTypeId => _viewModel.ProjectType.Id;

        public ProjectTeam Team => _viewModel.Team;

        public int UserId => _viewModel.UserId;

        public ProjectWorldSeries WorldSeries => _viewModel.WorldSeries;
    }
}
