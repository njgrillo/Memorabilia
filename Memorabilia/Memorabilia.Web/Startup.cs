using Demo.Framework.Web;
using MediatR;
using Memorabilia.Application.Features.Admin.AcquisitionTypes;
using Memorabilia.Application.Features.Admin.AuthenticationCompanies;
using Memorabilia.Application.Features.Admin.BaseballTypes;
using Memorabilia.Application.Features.Admin.BasketballTypes;
using Memorabilia.Application.Features.Admin.BatTypes;
using Memorabilia.Application.Features.Admin.Brands;
using Memorabilia.Application.Features.Admin.Colors;
using Memorabilia.Application.Features.Admin.Commissioners;
using Memorabilia.Application.Features.Admin.Conditions;
using Memorabilia.Application.Features.Admin.Conferences;
using Memorabilia.Application.Features.Admin.DashboardItems;
using Memorabilia.Application.Features.Admin.Divisions;
using Memorabilia.Application.Features.Admin.FigureSpecialtyTypes;
using Memorabilia.Application.Features.Admin.FigureTypes;
using Memorabilia.Application.Features.Admin.FootballTypes;
using Memorabilia.Application.Features.Admin.Franchises;
using Memorabilia.Application.Features.Admin.GameStyleTypes;
using Memorabilia.Application.Features.Admin.GloveTypes;
using Memorabilia.Application.Features.Admin.HelmetFinishes;
using Memorabilia.Application.Features.Admin.HelmetQualityTypes;
using Memorabilia.Application.Features.Admin.HelmetTypes;
using Memorabilia.Application.Features.Admin.ImageTypes;
using Memorabilia.Application.Features.Admin.InscriptionTypes;
using Memorabilia.Application.Features.Admin.ItemTypes;
using Memorabilia.Application.Features.Admin.ItemTypeBrand;
using Memorabilia.Application.Features.Admin.ItemTypeGameStyle;
using Memorabilia.Application.Features.Admin.ItemTypeLevel;
using Memorabilia.Application.Features.Admin.ItemTypeSizes;
using Memorabilia.Application.Features.Admin.ItemTypeSports;
using Memorabilia.Application.Features.Admin.ItemTypeSpots;
using Memorabilia.Application.Features.Admin.JerseyQualityTypes;
using Memorabilia.Application.Features.Admin.JerseyStyleTypes;
using Memorabilia.Application.Features.Admin.JerseyTypes;
using Memorabilia.Application.Features.Admin.Leagues;
using Memorabilia.Application.Features.Admin.LevelTypes;
using Memorabilia.Application.Features.Admin.MagazineTypes;
using Memorabilia.Application.Features.Admin.Occupations;
using Memorabilia.Application.Features.Admin.Orientations;
using Memorabilia.Application.Features.Admin.People;
using Memorabilia.Application.Features.Admin.Pewters;
using Memorabilia.Application.Features.Admin.PhotoTypes;
using Memorabilia.Application.Features.Admin.PrivacyTypes;
using Memorabilia.Application.Features.Admin.PurchaseTypes;
using Memorabilia.Application.Features.Admin.Sizes;
using Memorabilia.Application.Features.Admin.Sports;
using Memorabilia.Application.Features.Admin.SportLeagueLevel;
using Memorabilia.Application.Features.Admin.Spots;
using Memorabilia.Application.Features.Admin.Teams;
using Memorabilia.Application.Features.Admin.WritingInstruments;
using Memorabilia.Application.Features.Autograph;
using Memorabilia.Application.Features.Autograph.Inscriptions;
using Memorabilia.Application.Features.Memorabilia;
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
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MudBlazor.Services;
using System;
using MudBlazor;

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
            services.AddDbContext<Context>(options => options.UseSqlServer("name=ConnectionStrings:Memorabilia"), ServiceLifetime.Transient);
            services.AddTransient<IContext, Context>();
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
            services.AddTransient<IAuthenticationCompanyRepository, AuthenticationCompanyRepository>();            
            services.AddTransient<IAutographRepository, AutographRepository>();
            services.AddTransient<IBaseballTypeRepository, BaseballTypeRepository>();
            services.AddTransient<IBasketballTypeRepository, BasketballTypeRepository>();
            services.AddTransient<IBatTypeRepository, BatTypeRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();
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
            services.AddTransient<IGameStyleTypeRepository, GameStyleTypeRepository>();
            services.AddTransient<IGloveTypeRepository, GloveTypeRepository>();
            services.AddTransient<IHallOfFameRepository, HallOfFameRepository>();
            services.AddTransient<IHelmetFinishRepository, HelmetFinishRepository>();
            services.AddTransient<IHelmetQualityTypeRepository, HelmetQualityTypeRepository>();
            services.AddTransient<IHelmetTypeRepository, HelmetTypeRepository>();
            services.AddTransient<IImageTypeRepository, ImageTypeRepository>();
            services.AddTransient<IInscriptionTypeRepository, InscriptionTypeRepository>();                      
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
            services.AddTransient<ILeagueRepository, LeagueRepository>();
            services.AddTransient<ILevelTypeRepository, LevelTypeRepository>();
            services.AddTransient<IMagazineTypeRepository, MagazineTypeRepository>();
            services.AddTransient<IMemorabiliaBaseballRepository, MemorabiliaBaseballRepository>();
            services.AddTransient<IMemorabiliaBasketballRepository, MemorabiliaBasketballRepository>();
            services.AddTransient<IMemorabiliaBatRepository, MemorabiliaBatRepository>();
            services.AddTransient<IMemorabiliaBrandRepository, MemorabiliaBrandRepository>();
            services.AddTransient<IMemorabiliaCardRepository, MemorabiliaCardRepository>();
            services.AddTransient<IMemorabiliaCommissionerRepository, MemorabiliaCommissionerRepository>();
            services.AddTransient<IMemorabiliaFootballRepository, MemorabiliaFootballRepository>();
            services.AddTransient<IMemorabiliaGameRepository, MemorabiliaGameRepository>();
            services.AddTransient<IMemorabiliaImageRepository, MemorabiliaImageRepository>();
            services.AddTransient<IMemorabiliaJerseyRepository, MemorabiliaJerseyRepository>();
            services.AddTransient<IMemorabiliaLevelTypeRepository, MemorabiliaLevelTypeRepository>();
            services.AddTransient<IMemorabiliaMagazineRepository, MemorabiliaMagazineRepository>();
            services.AddTransient<IMemorabiliaOrientationRepository, MemorabiliaOrientationRepository>();
            services.AddTransient<IMemorabiliaPersonRepository, MemorabiliaPersonRepository>();
            services.AddTransient<IMemorabiliaPhotoRepository, MemorabiliaPhotoRepository>();
            services.AddTransient<IMemorabiliaRepository, MemorabiliaRepository>();
            services.AddTransient<IMemorabiliaSizeRepository, MemorabiliaSizeRepository>();
            services.AddTransient<IMemorabiliaSportRepository, MemorabiliaSportRepository>();
            services.AddTransient<IMemorabiliaTeamRepository, MemorabiliaTeamRepository>();
            services.AddTransient<IOccupationRepository, OccupationRepository>();
            services.AddTransient<IOrientationRepository, OrientationRepository>();
            services.AddTransient<IPersonOccupationRepository, PersonOccupationRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IPersonTeamRepository, PersonTeamRepository>();
            services.AddTransient<IPewterRepository, PewterRepository>();
            services.AddTransient<IPhotoTypeRepository, PhotoTypeRepository>();
            services.AddTransient<IPrivacyTypeRepository, PrivacyTypeRepository>();
            services.AddTransient<IPurchaseTypeRepository, PurchaseTypeRepository>();
            services.AddTransient<ISizeRepository, SizeRepository>();
            services.AddTransient<ISportLeagueLevelRepository, SportLeagueLevelRepository>();
            services.AddTransient<ISportRepository, SportRepository>();
            services.AddTransient<ISpotRepository, SpotRepository>();
            services.AddTransient<ITeamConferenceRepository, TeamConferenceRepository>();
            services.AddTransient<ITeamDivisionRepository, TeamDivisionRepository>();
            services.AddTransient<ITeamLeagueRepository, TeamLeagueRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IWritingInstrumentRepository, WritingInstrumentRepository>();

            services.AddTransient<IDashboardItemFactory, DashboardItemFactory>();

            services.AddTransient<AddUser>();            

            services.AddTransient<GetAcquisitionType>();
            services.AddTransient<GetAcquisitionTypes>();
            services.AddTransient<GetAuthenticationCompanies>();
            services.AddTransient<GetAuthenticationCompany>();            
            services.AddTransient<GetAutograph>();
            services.AddTransient<GetAutographs>();
            services.AddTransient<GetBaseball>();
            services.AddTransient<GetBaseballType>();
            services.AddTransient<GetBaseballTypes>();
            services.AddTransient<GetBasketball>();
            services.AddTransient<GetBasketballType>();
            services.AddTransient<GetBasketballTypes>();
            services.AddTransient<GetBat>();
            services.AddTransient<GetBatType>();
            services.AddTransient<GetBatTypes>();
            services.AddTransient<GetBook>();
            services.AddTransient<GetBrand>();
            services.AddTransient<GetBrands>();
            services.AddTransient<GetCard>();
            services.AddTransient<GetColor>();
            services.AddTransient<GetColors>();
            services.AddTransient<GetCommissioner>();
            services.AddTransient<GetCommissioners>();
            services.AddTransient<GetConditions>();
            services.AddTransient<GetConference>();
            services.AddTransient<GetConferences>();
            services.AddTransient<GetConditions>();
            services.AddTransient<GetDashboardItem>();
            services.AddTransient<GetDashboardItems>();
            services.AddTransient<GetDivision>();
            services.AddTransient<GetDivisions>();
            services.AddTransient<GetFigure>();
            services.AddTransient<GetFigureSpecialtyType>();
            services.AddTransient<GetFigureSpecialtyTypes>();
            services.AddTransient<GetFigureType>();
            services.AddTransient<GetFigureTypes>();
            services.AddTransient<GetFirstDayCover>();
            services.AddTransient<GetFootball>();
            services.AddTransient<GetFootballType>();
            services.AddTransient<GetFootballTypes>();
            services.AddTransient<GetFranchise>();
            services.AddTransient<GetFranchises>();
            services.AddTransient<GetGameStyleType>();
            services.AddTransient<GetGameStyleTypes>();
            services.AddTransient<GetGlove>();
            services.AddTransient<GetGloveType>();
            services.AddTransient<GetGloveTypes>();
            services.AddTransient<GetHat>();
            services.AddTransient<GetHelmet>();
            services.AddTransient<GetHelmetFinish>();
            services.AddTransient<GetHelmetFinishes>();
            services.AddTransient<GetHelmetQualityType>();
            services.AddTransient<GetHelmetQualityTypes>();
            services.AddTransient<GetHelmetType>();
            services.AddTransient<GetHelmetTypes>();
            services.AddTransient<GetHockeyStick>();
            services.AddTransient<GetImageType>();
            services.AddTransient<GetImageTypes>();
            services.AddTransient<GetInscriptionTypes>();
            services.AddTransient<GetInscriptionTypes>();
            services.AddTransient<GetItemType>();
            services.AddTransient<GetItemTypes>();            
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
            services.AddTransient<GetJerseyQualityType>();
            services.AddTransient<GetJerseyQualityTypes>();
            services.AddTransient<GetJerseyStyleTypes>();
            services.AddTransient<GetJerseyStyleTypes>();
            services.AddTransient<GetJerseyTypes>();
            services.AddTransient<GetJerseyTypes>();
            services.AddTransient<GetLeague>();
            services.AddTransient<GetLeagues>();
            services.AddTransient<GetLevelType>();
            services.AddTransient<GetLevelTypes>();
            services.AddTransient<GetMagazine>();
            services.AddTransient<GetMagazineType>();
            services.AddTransient<GetMagazineTypes>();
            services.AddTransient<GetMemorabiliaItem>();
            services.AddTransient<GetMemorabiliaItems>();
            services.AddTransient<GetDashboard>();
            services.AddTransient<GetOccupation>();
            services.AddTransient<GetOccupations>();
            services.AddTransient<GetOrientation>();
            services.AddTransient<GetOrientations>();
            services.AddTransient<GetPeople>();
            services.AddTransient<GetPerson>();
            services.AddTransient<GetPersonHallOfFames>();
            services.AddTransient<GetPersonOccupations>();
            services.AddTransient<GetPersonTeams>();            
            services.AddTransient<GetPewter>();
            services.AddTransient<GetPewters>();
            services.AddTransient<GetPhoto>();
            services.AddTransient<GetPhotoType>();
            services.AddTransient<GetPhotoTypes>();
            services.AddTransient<GetPrivacyType>();
            services.AddTransient<GetPrivacyTypes>();
            services.AddTransient<GetPuck>();
            services.AddTransient<GetPurchaseType>();
            services.AddTransient<GetPurchaseTypes>();
            services.AddTransient<GetPylon>();
            services.AddTransient<GetShoe>();
            services.AddTransient<GetSize>();
            services.AddTransient<GetSizes>();
            services.AddTransient<GetSoccerball>();
            services.AddTransient<GetSport>();
            services.AddTransient<GetSportLeagueLevel>();
            services.AddTransient<GetSportLeagueLevels>();            
            services.AddTransient<GetSports>();
            services.AddTransient<GetSpot>();
            services.AddTransient<GetSpots>();
            services.AddTransient<GetTeam>();
            services.AddTransient<GetTeams>();
            services.AddTransient<GetTicket>();
            services.AddTransient<GetWritingInstrument>();
            services.AddTransient<GetWritingInstruments>();
            services.AddTransient<GetUser>();
            services.AddTransient<GetUserDashboardItems>();            
            services.AddTransient<SaveAcquisitionType>();
            services.AddTransient<SaveAuthenticationCompany>();            
            services.AddTransient<SaveAutograph>();
            services.AddTransient<SaveBaseball>();
            services.AddTransient<SaveBaseballType>();
            services.AddTransient<SaveBasketball>();
            services.AddTransient<SaveBasketballType>();
            services.AddTransient<SaveBat>();
            services.AddTransient<SaveBatType>();
            services.AddTransient<SaveBook>();
            services.AddTransient<SaveBrand>();
            services.AddTransient<SaveCard>();
            services.AddTransient<SaveColor>();
            services.AddTransient<SaveCommissioner>();
            services.AddTransient<SaveCondition>();
            services.AddTransient<SaveConference>();
            services.AddTransient<SaveDashboardItem>();
            services.AddTransient<SaveDivision>();
            services.AddTransient<SaveFigure>();
            services.AddTransient<SaveFigureSpecialtyType>();
            services.AddTransient<SaveFigureType>();
            services.AddTransient<SaveFirstDayCover>();
            services.AddTransient<SaveFootball>();
            services.AddTransient<SaveFootballType>();
            services.AddTransient<SaveFranchise>();
            services.AddTransient<SaveGameStyleType>();
            services.AddTransient<SaveGlove>();
            services.AddTransient<SaveGloveType>();
            services.AddTransient<SaveHat>();
            services.AddTransient<SaveHelmet>();
            services.AddTransient<SaveHelmetFinish>();
            services.AddTransient<SaveHelmetQualityType>();
            services.AddTransient<SaveHelmetType>();
            services.AddTransient<SaveHockeyStick>();
            services.AddTransient<SaveImageType>();
            services.AddTransient<SaveInscriptions>();
            services.AddTransient<SaveInscriptionType>();
            services.AddTransient<SaveItemType>();           
            services.AddTransient<SaveItemTypeBrand>();
            services.AddTransient<SaveItemTypeGameStyle>();
            services.AddTransient<SaveItemTypeLevel>();
            services.AddTransient<SaveItemTypeSize>();
            services.AddTransient<SaveItemTypeSport>();
            services.AddTransient<SaveItemTypeSpot>();            
            services.AddTransient<SaveJersey>();
            services.AddTransient<SaveJerseyQualityType>();
            services.AddTransient<SaveJerseyStyleType>();
            services.AddTransient<SaveJerseyType>();
            services.AddTransient<SaveLeague>();
            services.AddTransient<SaveLevelType>();
            services.AddTransient<SaveMagazine>();
            services.AddTransient<SaveMagazineType>();
            services.AddTransient<SaveMemorabiliaItem>();
            services.AddTransient<SaveOccupation>();
            services.AddTransient<SaveOrientation>();
            services.AddTransient<SavePerson>();
            services.AddTransient<SavePersonHallOfFame>();
            services.AddTransient<SavePersonOccupation>();
            services.AddTransient<SavePersonTeam>();
            services.AddTransient<SavePewter>();
            services.AddTransient<SavePhoto>();
            services.AddTransient<SavePhotoType>();
            services.AddTransient<SavePrivacyType>();
            services.AddTransient<SavePuck>();
            services.AddTransient<SavePurchaseType>();
            services.AddTransient<SavePylon>();
            services.AddTransient<SaveShoe>();
            services.AddTransient<SaveSize>();
            services.AddTransient<SaveSoccerball>();
            services.AddTransient<SaveSport>();
            services.AddTransient<SaveSpot>();
            services.AddTransient<SaveTeam>();
            services.AddTransient<SaveTicket>();
            services.AddTransient<SaveWritingInstrument>();
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
