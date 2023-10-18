namespace Memorabilia.MinimalAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAuthorization();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddMemoryCache();

        builder.Services.AddDbContext<MemorabiliaContext>(options => options.UseSqlServer("name=ConnectionStrings:Memorabilia"), ServiceLifetime.Transient);
        builder.Services.AddDbContext<DomainContext>(options => options.UseSqlServer("name=ConnectionStrings:Memorabilia"), ServiceLifetime.Transient);
        
        var assemblies = new[] { typeof(GetUser).Assembly, typeof(Program).Assembly };

        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetCommissioner).Assembly));

        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new RepositoryModule()));
        builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new ApplicationModule()));

        builder.Services.RegisterCachedRepositories();

        var imagePath = new ImagePath();
        builder.Configuration.GetSection("ImagePaths").Bind(imagePath);

        builder.Services.AddSingleton<IImagePath>(imagePath);
        builder.Services.AddSingleton<ImageService>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();

        app.MapDomainEndpoints();

        app.Run();
    }
}