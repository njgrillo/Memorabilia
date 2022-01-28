using Blazored.Toast;
using Demo.Framework.Web;
using MediatR;
using Memorabilia.Application.Features.Admin.AcquisitionType;
using Memorabilia.Application.Features.Admin.AuthenticationCompany;
using Memorabilia.Application.Features.Admin.BaseballType;
using Memorabilia.Application.Features.Admin.Brand;
using Memorabilia.Application.Features.Admin.Color;
using Memorabilia.Application.Features.Admin.Commissioner;
using Memorabilia.Application.Features.Admin.Condition;
using Memorabilia.Application.Features.Admin.Franchise;
using Memorabilia.Application.Features.Admin.FullSizeHelmetType;
using Memorabilia.Application.Features.Admin.GloveType;
using Memorabilia.Application.Features.Admin.HelmetType;
using Memorabilia.Application.Features.Admin.InscriptionType;
using Memorabilia.Application.Features.Admin.ItemType;
using Memorabilia.Application.Features.Admin.ItemTypeBrand;
using Memorabilia.Application.Features.Admin.ItemTypeSize;
using Memorabilia.Application.Features.Admin.ItemTypeSport;
using Memorabilia.Application.Features.Admin.ItemTypeSpot;
using Memorabilia.Application.Features.Admin.JerseyLevelType;
using Memorabilia.Application.Features.Admin.JerseyNumberType;
using Memorabilia.Application.Features.Admin.JerseyType;
using Memorabilia.Application.Features.Admin.MagazineType;
using Memorabilia.Application.Features.Admin.Occupation;
using Memorabilia.Application.Features.Admin.Person;
using Memorabilia.Application.Features.Admin.Size;
using Memorabilia.Application.Features.Admin.Sport;
using Memorabilia.Application.Features.Admin.Spot;
using Memorabilia.Application.Features.Admin.Team;
using Memorabilia.Application.Features.Admin.WritingInstrument;
using Memorabilia.Application.Features.Autograph;
using Memorabilia.Application.Features.Memorabilia;
using Memorabilia.Application.Features.Memorabilia.Baseball;
using Memorabilia.Application.Features.User;
using Memorabilia.Application.Features.User.Register;
using Memorabilia.Domain;
using Memorabilia.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

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
                //.PersistKeysToDbContext<ApplicationDbContext>()
                .SetApplicationName("Memorabilia")
                .SetDefaultKeyLifetime(TimeSpan.FromDays(180));

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddBlazoredToast();
            services.AddDbContext<Context>(options => options.UseSqlServer("name=ConnectionStrings:Memorabilia"));
            services.AddTransient<IContext, Context>();
            services.AddTransient<CommandRouter>();
            services.AddTransient<QueryRouter>();
            services.AddMediatR();

            services.AddTransient<IAcquisitionTypeRepository, AcquisitionTypeRepository>();
            services.AddTransient<IAuthenticationCompanyRepository, AuthenticationCompanyRepository>();
            services.AddTransient<IAutographRepository, AutographRepository>();
            services.AddTransient<IBaseballTypeRepository, BaseballTypeRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<IColorRepository, ColorRepository>();
            services.AddTransient<ICommissionerRepository, CommissionerRepository>();
            services.AddTransient<IConditionRepository, ConditionRepository>();
            services.AddTransient<IFranchiseRepository, FranchiseRepository>();
            services.AddTransient<IFullSizeHelmetTypeRepository, FullSizeHelmetTypeRepository>();
            services.AddTransient<IGloveTypeRepository, GloveTypeRepository>();
            services.AddTransient<IHelmetTypeRepository, HelmetTypeRepository>();
            services.AddTransient<IInscriptionTypeRepository, InscriptionTypeRepository>();
            services.AddTransient<IItemTypeRepository, ItemTypeRepository>();
            services.AddTransient<IItemTypeBrandRepository, ItemTypeBrandRepository>();
            services.AddTransient<IItemTypeSizeRepository, ItemTypeSizeRepository>();
            services.AddTransient<IItemTypeSportRepository, ItemTypeSportRepository>();
            services.AddTransient<IItemTypeSpotRepository, ItemTypeSpotRepository>();
            services.AddTransient<IJerseyLevelTypeRepository, JerseyLevelTypeRepository>();
            services.AddTransient<IJerseyNumberTypeRepository, JerseyNumberTypeRepository>();
            services.AddTransient<IJerseyTypeRepository, JerseyTypeRepository>();
            services.AddTransient<IMagazineTypeRepository, MagazineTypeRepository>();
            services.AddTransient<IMemorabiliaBaseballTypeRepository, MemorabiliaBaseballTypeRepository>();
            services.AddTransient<IMemorabiliaBrandRepository, MemorabiliaBrandRepository>();
            services.AddTransient<IMemorabiliaCommissionerRepository, MemorabiliaCommissionerRepository>();
            services.AddTransient<IMemorabiliaPersonRepository, MemorabiliaPersonRepository>();
            services.AddTransient<IMemorabiliaRepository, MemorabiliaRepository>();
            services.AddTransient<IMemorabiliaSizeRepository, MemorabiliaSizeRepository>();
            services.AddTransient<IMemorabiliaSportRepository, MemorabiliaSportRepository>();
            services.AddTransient<IMemorabiliaTeamRepository, MemorabiliaTeamRepository>();
            services.AddTransient<IOccupationRepository, OccupationRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<ISizeRepository, SizeRepository>();
            services.AddTransient<ISportRepository, SportRepository>();
            services.AddTransient<ISpotRepository, SpotRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IWritingInstrumentRepository, WritingInstrumentRepository>();

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
            services.AddTransient<GetBrand>();
            services.AddTransient<GetBrands>();
            services.AddTransient<GetColor>();
            services.AddTransient<GetColors>();
            services.AddTransient<GetCommissioner>();
            services.AddTransient<GetCommissioners>();
            services.AddTransient<GetConditions>();
            services.AddTransient<GetConditions>();
            services.AddTransient<GetFranchise>();
            services.AddTransient<GetFranchises>();
            services.AddTransient<GetFullSizeHelmetType>();
            services.AddTransient<GetFullSizeHelmetTypes>();
            services.AddTransient<GetGloveType>();
            services.AddTransient<GetGloveTypes>();
            services.AddTransient<GetHelmetType>();
            services.AddTransient<GetHelmetTypes>();
            services.AddTransient<GetInscriptionType>();
            services.AddTransient<GetInscriptionTypes>();
            services.AddTransient<GetItemType>();
            services.AddTransient<GetItemTypes>();
            services.AddTransient<GetItemTypeBrand>();
            services.AddTransient<GetItemTypeBrands>();
            services.AddTransient<GetItemTypeSizes>();
            services.AddTransient<GetItemTypeSizes>();
            services.AddTransient<GetItemTypeSport>();
            services.AddTransient<GetItemTypeSports>();
            services.AddTransient<GetItemTypeSpot>();
            services.AddTransient<GetItemTypeSpots>();
            services.AddTransient<GetJerseyLevelType>();
            services.AddTransient<GetJerseyLevelTypes>();
            services.AddTransient<GetJerseyNumberType>();
            services.AddTransient<GetJerseyNumberTypes>();
            services.AddTransient<GetJerseyTypes>();
            services.AddTransient<GetJerseyTypes>();
            services.AddTransient<GetMagazineType>();
            services.AddTransient<GetMagazineTypes>();
            services.AddTransient<GetMemorabiliaItem>();
            services.AddTransient<GetMemorabiliaItems>();
            services.AddTransient<GetOccupation>();
            services.AddTransient<GetOccupations>();
            services.AddTransient<GetPerson>();
            services.AddTransient<GetPeople>();
            services.AddTransient<GetSize>();
            services.AddTransient<GetSizes>();
            services.AddTransient<GetSport>();
            services.AddTransient<GetSports>();
            services.AddTransient<GetSpot>();
            services.AddTransient<GetSpots>();
            services.AddTransient<GetTeam>();
            services.AddTransient<GetTeams>();
            services.AddTransient<GetWritingInstrument>();
            services.AddTransient<GetWritingInstruments>();
            services.AddTransient<GetUser>();
            
            services.AddTransient<SaveAcquisitionType>();
            services.AddTransient<SaveAuthenticationCompany>();
            services.AddTransient<SaveAutograph>();
            services.AddTransient<SaveBaseball>();
            services.AddTransient<SaveBaseballType>();
            services.AddTransient<SaveBrand>();
            services.AddTransient<SaveColor>();
            services.AddTransient<SaveCommissioner>();
            services.AddTransient<SaveCondition>();
            services.AddTransient<SaveFranchise>();
            services.AddTransient<SaveFullSizeHelmetType>();
            services.AddTransient<SaveGloveType>();
            services.AddTransient<SaveHelmetType>();
            services.AddTransient<SaveInscriptionType>();
            services.AddTransient<SaveItemType>();
            services.AddTransient<SaveItemTypeBrand>();
            services.AddTransient<SaveItemTypeSize>();
            services.AddTransient<SaveItemTypeSport>();
            services.AddTransient<SaveItemTypeSpot>();
            services.AddTransient<SaveJerseyLevelType>();
            services.AddTransient<SaveJerseyNumberType>();
            services.AddTransient<SaveJerseyType>();
            services.AddTransient<SaveMagazineType>();
            services.AddTransient<SaveMemorabiliaItem>();
            services.AddTransient<SaveOccupation>();
            services.AddTransient<SavePerson>();
            services.AddTransient<SaveSize>();
            services.AddTransient<SaveSport>();
            services.AddTransient<SaveSpot>();
            services.AddTransient<SaveTeam>();
            services.AddTransient<SaveWritingInstrument>();
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
