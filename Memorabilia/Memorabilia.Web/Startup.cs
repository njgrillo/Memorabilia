using MediatR;
using Memorabilia.Application.Features.Admin.Brands;
using Memorabilia.Application.Features.Admin.Commissioners;
using Memorabilia.Application.Features.Admin.Conditions;
using Memorabilia.Application.Features.Admin.Conferences;
using Memorabilia.Application.Features.Admin.DashboardItems;
using Memorabilia.Application.Features.Admin.Divisions;
using Memorabilia.Application.Features.Admin.Franchises;
using Memorabilia.Application.Features.Admin.ItemTypeBrand;
using Memorabilia.Application.Features.Admin.ItemTypeGameStyle;
using Memorabilia.Application.Features.Admin.ItemTypeLevel;
using Memorabilia.Application.Features.Admin.ItemTypeSizes;
using Memorabilia.Application.Features.Admin.ItemTypeSports;
using Memorabilia.Application.Features.Admin.ItemTypeSpots;
using Memorabilia.Application.Features.Admin.Leagues;
using Memorabilia.Application.Features.Admin.Occupations;
using Memorabilia.Application.Features.Admin.Orientations;
using Memorabilia.Application.Features.Admin.People;
using Memorabilia.Application.Features.Admin.Pewters;
using Memorabilia.Application.Features.Admin.Sizes;
using Memorabilia.Application.Features.Admin.Sports;
using Memorabilia.Application.Features.Admin.SportLeagueLevel;
using Memorabilia.Application.Features.Admin.Teams;
using Memorabilia.Application.Features.Autograph;
using Memorabilia.Application.Features.Autograph.Inscriptions;
using Memorabilia.Application.Features.Memorabilia.Baseball;
using Memorabilia.Application.Features.Memorabilia.Basketball;
using Memorabilia.Application.Features.Memorabilia.Bat;
using Memorabilia.Application.Features.Memorabilia.Book;
using Memorabilia.Application.Features.Memorabilia.Card;
using Memorabilia.Application.Features.Memorabilia.Figure;
using Memorabilia.Application.Features.Memorabilia.FirstDayCover;
using Memorabilia.Application.Features.Memorabilia.Football;
using Memorabilia.Application.Features.Memorabilia.Glove;
using Memorabilia.Application.Features.Memorabilia.Hat;
using Memorabilia.Application.Features.Memorabilia.Helmet;
using Memorabilia.Application.Features.Memorabilia.HockeyStick;
using Memorabilia.Application.Features.Memorabilia.Jersey;
using Memorabilia.Application.Features.Memorabilia.Magazine;
using Memorabilia.Application.Features.Memorabilia.Photo;
using Memorabilia.Application.Features.Memorabilia.Puck;
using Memorabilia.Application.Features.Memorabilia.Pylon;
using Memorabilia.Application.Features.Memorabilia.Shoe;
using Memorabilia.Application.Features.Memorabilia.Soccerball;
using Memorabilia.Application.Features.Memorabilia.Ticket;
using Memorabilia.Application.Features.Services.Dashboard;
using Memorabilia.Application.Features.User;
using Memorabilia.Application.Features.User.Dashboard;
using Memorabilia.Application.Features.User.Register;
using Memorabilia.Repository;
using Memorabilia.Repository.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MudBlazor.Services;
using Memorabilia.Application.Features.Services.Tools.Profile.Rules;
using Memorabilia.Application.Features.Services.Tools.Profile;
using Memorabilia.Application.Features.Admin.Colleges;
using Memorabilia.Application.Features.Admin.ChampionTypes;
using Memorabilia.Application.Features.Project;
using Memorabilia.Application.Features.Tools.Baseball.Awards;
using Memorabilia.Application.Features.Tools.Baseball.Accomplishments;

namespace Memorabilia.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataProtection()
                    .SetApplicationName("Memorabilia")
                    .SetDefaultKeyLifetime(TimeSpan.FromDays(180));

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddDbContext<MemorabiliaContext>(options => options.UseSqlServer("name=ConnectionStrings:Memorabilia"), ServiceLifetime.Transient);
            services.AddTransient<IMemorabiliaContext, MemorabiliaContext>();
            services.AddDbContext<DomainContext>(options => options.UseSqlServer("name=ConnectionStrings:Memorabilia"), ServiceLifetime.Transient);
            services.AddTransient<IDomainContext, DomainContext>();
            services.AddTransient<CommandRouter>();
            services.AddTransient<QueryRouter>();
            services.AddMediatR();

            services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
                config.SnackbarConfiguration.PreventDuplicates = false;
                config.SnackbarConfiguration.NewestOnTop = false;
                config.SnackbarConfiguration.ShowCloseIcon = true;
                config.SnackbarConfiguration.VisibleStateDuration = 10000;
                config.SnackbarConfiguration.HideTransitionDuration = 500;
                config.SnackbarConfiguration.ShowTransitionDuration = 500;
                config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
            });

            services.AddTransient<IAcquisitionTypeRepository, AcquisitionTypeRepository>();
            services.AddTransient<IAccomplishmentTypeRepository, AccomplishmentTypeRepository>();
            services.AddTransient<IAuthenticationCompanyRepository, AuthenticationCompanyRepository>();            
            services.AddTransient<IAutographRepository, AutographRepository>();
            services.AddTransient<IAwardTypeRepository, AwardTypeRepository>();
            services.AddTransient<IBammerTypeRepository, BammerTypeRepository>();
            services.AddTransient<IBaseballTypeRepository, BaseballTypeRepository>();
            services.AddTransient<IBasketballTypeRepository, BasketballTypeRepository>();
            services.AddTransient<IBatTypeRepository, BatTypeRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();            
            services.AddTransient<IChampionTypeRepository, ChampionTypeRepository>();
            services.AddTransient<ICollegeRepository, CollegeRepository>();
            services.AddTransient<IColorRepository, ColorRepository>();
            services.AddTransient<ICommissionerRepository, CommissionerRepository>();
            services.AddTransient<IConditionRepository, ConditionRepository>();
            services.AddTransient<IConferenceRepository, ConferenceRepository>();
            services.AddTransient<IDashboardItemRepository, DashboardItemRepository>();
            services.AddTransient<IDivisionRepository, DivisionRepository>();
            services.AddTransient<IFigureSpecialtyTypeRepository, FigureSpecialtyTypeRepository>();
            services.AddTransient<IFigureTypeRepository, FigureTypeRepository>();
            services.AddTransient<IFootballTypeRepository, FootballTypeRepository>();
            services.AddTransient<IFranchiseRepository, FranchiseRepository>();
            services.AddTransient<IFranchiseHallOfFameTypeRepository, FranchiseHallOfFameTypeRepository>();
            services.AddTransient<IGameStyleTypeRepository, GameStyleTypeRepository>();
            services.AddTransient<IGloveTypeRepository, GloveTypeRepository>();
            services.AddTransient<IHallOfFameRepository, HallOfFameRepository>();
            services.AddTransient<IHelmetFinishRepository, HelmetFinishRepository>();
            services.AddTransient<IHelmetQualityTypeRepository, HelmetQualityTypeRepository>();
            services.AddTransient<IHelmetTypeRepository, HelmetTypeRepository>();
            services.AddTransient<IImageTypeRepository, ImageTypeRepository>();
            services.AddTransient<IInscriptionTypeRepository, InscriptionTypeRepository>();                      
            services.AddTransient<IInternationalHallOfFameTypeRepository, InternationalHallOfFameTypeRepository>();                      
            services.AddTransient<IItemTypeBrandRepository, ItemTypeBrandRepository>();
            services.AddTransient<IItemTypeGameStyleTypeRepository, ItemTypeGameStyleTypeRepository>();
            services.AddTransient<IItemTypeLevelRepository, ItemTypeLevelRepository>();
            services.AddTransient<IItemTypeRepository, ItemTypeRepository>();
            services.AddTransient<IItemTypeSizeRepository, ItemTypeSizeRepository>();
            services.AddTransient<IItemTypeSportRepository, ItemTypeSportRepository>();
            services.AddTransient<IItemTypeSpotRepository, ItemTypeSpotRepository>();           
            services.AddTransient<IJerseyQualityTypeRepository, JerseyQualityTypeRepository>();
            services.AddTransient<IJerseyStyleTypeRepository, JerseyStyleTypeRepository>();
            services.AddTransient<IJerseyTypeRepository, JerseyTypeRepository>();
            services.AddTransient<ILeaderTypeRepository, LeaderTypeRepository>();
            services.AddTransient<ILeagueRepository, LeagueRepository>();
            services.AddTransient<ILevelTypeRepository, LevelTypeRepository>();
            services.AddTransient<IMagazineTypeRepository, MagazineTypeRepository>();
            services.AddTransient<IMemorabiliaImageRepository, MemorabiliaImageRepository>();
            services.AddTransient<IMemorabiliaRepository, MemorabiliaRepository>();
            services.AddTransient<IOccupationRepository, OccupationRepository>();
            services.AddTransient<IOrientationRepository, OrientationRepository>();
            services.AddTransient<IPersonAccomplishmentRepository, PersonAccomplishmentRepository>();
            services.AddTransient<IPersonAwardRepository, PersonAwardRepository>();
            services.AddTransient<IPersonNicknameRepository, PersonNicknameRepository>();
            services.AddTransient<IPersonOccupationRepository, PersonOccupationRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IPersonTeamRepository, PersonTeamRepository>();
            services.AddTransient<IPewterRepository, PewterRepository>();
            services.AddTransient<IPhotoTypeRepository, PhotoTypeRepository>();
            services.AddTransient<IPriorityTypeRepository, PriorityTypeRepository>();
            services.AddTransient<IPrivacyTypeRepository, PrivacyTypeRepository>();
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<IPurchaseTypeRepository, PurchaseTypeRepository>();
            services.AddTransient<IRecordTypeRepository, RecordTypeRepository>();
            services.AddTransient<ISizeRepository, SizeRepository>();
            services.AddTransient<ISportLeagueLevelRepository, SportLeagueLevelRepository>();
            services.AddTransient<ISportRepository, SportRepository>();
            services.AddTransient<ISportServiceRepository, SportServiceRepository>();
            services.AddTransient<ISpotRepository, SpotRepository>();
            services.AddTransient<ITeamChampionshipRepository, TeamChampionshipRepository>();
            services.AddTransient<ITeamConferenceRepository, TeamConferenceRepository>();
            services.AddTransient<ITeamDivisionRepository, TeamDivisionRepository>();
            services.AddTransient<ITeamLeagueRepository, TeamLeagueRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddTransient<ITeamRoleTypeRepository, TeamRoleTypeRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IWritingInstrumentRepository, WritingInstrumentRepository>();

            services.AddTransient<IDashboardItemFactory, DashboardItemFactory>();
            services.AddTransient<IProfileRuleFactory, ProfileRuleFactory>();
            services.AddTransient<IProfileService, ProfileService>();

            services.AddTransient<AddUser>();            
          
            services.AddTransient<GetAccomplishments>();
            services.AddTransient<GetAutograph>();
            services.AddTransient<GetAutographs>();
            services.AddTransient<GetAwards>();
            services.AddTransient<GetBaseball>();
            services.AddTransient<GetBasketball>();
            services.AddTransient<GetBat>();
            services.AddTransient<GetBook>();
            services.AddTransient<GetBrand>();
            services.AddTransient<GetBrands>();
            services.AddTransient<GetCard>();
            services.AddTransient<GetChampionType>();
            services.AddTransient<GetChampionTypes>();
            services.AddTransient<GetCollege>();
            services.AddTransient<GetColleges>();
            services.AddTransient<GetCommissioner>();
            services.AddTransient<GetCommissioners>();
            services.AddTransient<GetConditions>();
            services.AddTransient<GetConference>();
            services.AddTransient<GetConferences>();
            services.AddTransient<GetDashboardItem>();
            services.AddTransient<GetDashboardItems>();
            services.AddTransient<GetDivision>();
            services.AddTransient<GetDivisions>();
            services.AddTransient<GetFigure>();
            services.AddTransient<GetFirstDayCover>();
            services.AddTransient<GetFootball>();
            services.AddTransient<GetFranchise>();
            services.AddTransient<GetFranchises>();
            services.AddTransient<GetGlove>();
            services.AddTransient<GetHat>();
            services.AddTransient<GetHelmet>();
            services.AddTransient<GetHockeyStick>();         
            services.AddTransient<GetItemTypeBrand>();
            services.AddTransient<GetItemTypeBrands>();
            services.AddTransient<GetItemTypeGameStyle>();
            services.AddTransient<GetItemTypeGameStyles>();
            services.AddTransient<GetItemTypeLevel>();
            services.AddTransient<GetItemTypeLevels>();
            services.AddTransient<GetItemTypeSizes>();
            services.AddTransient<GetItemTypeSizes>();
            services.AddTransient<GetItemTypeSport>();
            services.AddTransient<GetItemTypeSports>();
            services.AddTransient<GetItemTypeSpot>();
            services.AddTransient<GetItemTypeSpots>();            
            services.AddTransient<GetJersey>();
            services.AddTransient<GetLeague>();
            services.AddTransient<GetLeagues>();
            services.AddTransient<GetMagazine>();
            services.AddTransient<GetMemorabiliaItem>();
            services.AddTransient<GetMemorabiliaItems>();
            services.AddTransient<GetDashboard>();
            services.AddTransient<GetPeople>();
            services.AddTransient<GetPerson>();
            services.AddTransient<GetPersonHallOfFames>();
            services.AddTransient<GetPersonOccupations>();
            services.AddTransient<GetPersonSportService>();            
            services.AddTransient<GetPersonTeams>();            
            services.AddTransient<GetPewter>();
            services.AddTransient<GetPewters>();
            services.AddTransient<GetPhoto>();
            services.AddTransient<GetProject>();
            services.AddTransient<GetProjects>();
            services.AddTransient<GetPuck>();
            services.AddTransient<GetPylon>();
            services.AddTransient<GetShoe>();
            services.AddTransient<GetSize>();
            services.AddTransient<GetSizes>();
            services.AddTransient<GetSoccerball>();
            services.AddTransient<GetSport>();
            services.AddTransient<GetSportLeagueLevel>();
            services.AddTransient<GetSportLeagueLevels>();            
            services.AddTransient<GetSports>();
            services.AddTransient<GetTeam>();
            services.AddTransient<GetTeams>();
            services.AddTransient<GetTicket>();
            services.AddTransient<GetUser>();
            services.AddTransient<GetUserDashboardItems>(); 
                      
            services.AddTransient<SaveAutograph>();
            services.AddTransient<SaveBaseball>();
            services.AddTransient<SaveBasketball>();
            services.AddTransient<SaveBat>();
            services.AddTransient<SaveBook>();
            services.AddTransient<SaveBrand>();
            services.AddTransient<SaveCard>();
            services.AddTransient<SaveChampionType>();
            services.AddTransient<SaveCollege>();
            services.AddTransient<SaveCommissioner>();
            services.AddTransient<SaveConference>();
            services.AddTransient<SaveDashboardItem>();
            services.AddTransient<SaveDivision>();
            services.AddTransient<SaveFigure>();
            services.AddTransient<SaveFirstDayCover>();
            services.AddTransient<SaveFootball>();
            services.AddTransient<SaveFranchise>();
            services.AddTransient<SaveGlove>();
            services.AddTransient<SaveHat>();
            services.AddTransient<SaveHelmet>();
            services.AddTransient<SaveHockeyStick>();
            services.AddTransient<SaveInscriptions>();       
            services.AddTransient<SaveItemTypeBrand>();
            services.AddTransient<SaveItemTypeGameStyle>();
            services.AddTransient<SaveItemTypeLevel>();
            services.AddTransient<SaveItemTypeSize>();
            services.AddTransient<SaveItemTypeSport>();
            services.AddTransient<SaveItemTypeSpot>();            
            services.AddTransient<SaveJersey>();
            services.AddTransient<SaveLeague>();
            services.AddTransient<SaveMagazine>();
            services.AddTransient<SaveMemorabiliaItem>();
            services.AddTransient<SaveOccupation>();
            services.AddTransient<SaveOrientation>();
            services.AddTransient<SavePerson>();
            services.AddTransient<SavePersonHallOfFame>();
            services.AddTransient<SavePersonOccupation>();
            services.AddTransient<SavePersonSportService>();
            services.AddTransient<SavePersonTeam>();
            services.AddTransient<SavePewter>();
            services.AddTransient<SavePhoto>();
            services.AddTransient<SaveProject>();
            services.AddTransient<SavePuck>();
            services.AddTransient<SavePylon>();
            services.AddTransient<SaveShoe>();
            services.AddTransient<SaveSize>();
            services.AddTransient<SaveSoccerball>();
            services.AddTransient<SaveSport>();
            services.AddTransient<SaveTeam>();
            services.AddTransient<SaveTicket>();
            services.AddTransient<SaveUserDashboard>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
