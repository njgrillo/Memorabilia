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
            Entity.Project project;

            if (command.IsNew)
            {
                project = new Entity.Project(command.Name, 
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

        private static void DeleteProjectMemorabiliaTeams(Entity.Project project, Command command)
        {
            if (!command.DeleteMemorabiliaTeamIds.Any())
                return;

            project.RemoveMemorabiliaTeams(command.DeleteMemorabiliaTeamIds);
        }

        private static void DeleteProjectPeople(Entity.Project project, Command command)
        {
            if (!command.DeletePeopleIds.Any())
                return;

            project.RemovePeople(command.DeletePeopleIds);
        }

        private static void SetProjectDetails(Command command, Entity.Project project)
        {
            var projectType = Constant.ProjectType.Find(command.ProjectTypeId);

            if (projectType == Constant.ProjectType.BaseballType)
            {
                project.SetBaseball(command.Baseball.BaseballTypeId,
                                    command.Baseball.TeamId,
                                    command.Baseball.Year);

                return;
            }

            if (projectType == Constant.ProjectType.Card)
            {
                project.SetCard(command.Card.BrandId,
                                command.Card.TeamId,
                                command.Card.Year);

                return;
            }

            if (projectType == Constant.ProjectType.HallOfFame)
            {
                project.SetHallOfFame(command.HallOfFame.SportLeagueLevelId,
                                      command.HallOfFame.Year,
                                      command.HallOfFame.ItemTypeId);

                return;
            }

            if (projectType == Constant.ProjectType.HelmetType)
            {
                project.SetHelmet(command.Helmet.HelmetTypeId,
                                  command.Helmet.HelmetFinishId,
                                  command.Helmet.SizeId);

                return;
            }

            if (projectType == Constant.ProjectType.ItemType)
            {
                project.SetItem(command.Item.ItemTypeId,
                                command.Item.MultiSignedItem);

                return;
            }

            if (projectType == Constant.ProjectType.Team)
            {
                project.SetTeam(command.Team.TeamId, 
                                command.Team.Year);

                return;
            }

            if (projectType == Constant.ProjectType.WorldSeries)
            {
                project.SetWorldSeries(command.WorldSeries.TeamId,
                                       command.WorldSeries.Year,
                                       command.WorldSeries.ItemTypeId);

                return;
            }
        }

        private static void SetProjectMemorabiliaTeams(Entity.Project project, Command command)
        {
            foreach (ProjectMemorabiliaTeamEditModel projectMemorabiliaTeam in command.MemorabiliaTeams.Where(item => !item.IsDeleted))
            {
                project.SetMemorabliaTeam(projectMemorabiliaTeam.Id,
                                          projectMemorabiliaTeam.Team.Id,
                                          projectMemorabiliaTeam.ItemTypeId,
                                          projectMemorabiliaTeam.Upgrade,
                                          projectMemorabiliaTeam.Rank,
                                          projectMemorabiliaTeam.EstimatedCost,
                                          projectMemorabiliaTeam.PriorityTypeId,
                                          projectMemorabiliaTeam.ProjectStatusTypeId > 0 ? projectMemorabiliaTeam.ProjectStatusTypeId : null,
                                          projectMemorabiliaTeam.MemorabiliaId > 0 ? projectMemorabiliaTeam.MemorabiliaId : null);
            }
        }

        private static void SetProjectPeople(Entity.Project project, Command command)
        {
            foreach (ProjectPersonEditModel projectPerson in command.People.Where(person => !person.IsDeleted))
            {
                project.SetPerson(projectPerson.Id,
                                  projectPerson.Person.Id,
                                  projectPerson.ItemTypeId,
                                  projectPerson.Upgrade,
                                  projectPerson.Rank,
                                  projectPerson.PriorityTypeId,
                                  projectPerson.ProjectStatusTypeId > 0 ? projectPerson.ProjectStatusTypeId : null,
                                  projectPerson.EstimatedCost,
                                  projectPerson.MemorabiliaId > 0 ? projectPerson.MemorabiliaId : null,
                                  projectPerson.AutographId > 0 ? projectPerson.AutographId : null);
            }
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly ProjectEditModel _editModel;

        public Command(ProjectEditModel editModel)
        {
            _editModel = editModel;

            Id = _editModel.Id;
        }

        public Entity.ProjectBaseball Baseball 
            => _editModel.Baseball;

        public Entity.ProjectCard Card 
            => _editModel.Card;

        public int[] DeleteMemorabiliaTeamIds 
            => _editModel.MemorabiliaTeams
                         .Where(item => item.IsDeleted)
                         .Select(item => item.Id)
                         .ToArray();

        public int[] DeletePeopleIds 
            => _editModel.People
                         .Where(person => person.IsDeleted)
                         .Select(person => person.Id)
                         .ToArray();

        public DateTime? EndDate 
            => _editModel.EndDate;

        public Entity.ProjectHallOfFame HallOfFame 
            => _editModel.HallOfFame;

        public Entity.ProjectHelmet Helmet 
            => _editModel.Helmet;

        public int Id { get; set; }

        public bool IsDeleted 
            => _editModel.IsDeleted;

        public bool IsNew 
            => _editModel.IsNew;

        public Entity.ProjectItem Item 
            => _editModel.Item;

        public List<ProjectMemorabiliaTeamEditModel> MemorabiliaTeams 
            => _editModel.MemorabiliaTeams;

        public string Name 
            => _editModel.Name;

        public List<ProjectPersonEditModel> People 
            => _editModel.People;

        public DateTime? StartDate 
            => _editModel.StartDate;

        public int ProjectTypeId 
            => _editModel.ProjectType.Id;

        public Entity.ProjectTeam Team 
            => _editModel.Team;

        public int UserId 
            => _editModel.UserId;

        public Entity.ProjectWorldSeries WorldSeries 
            => _editModel.WorldSeries;
    }
}
