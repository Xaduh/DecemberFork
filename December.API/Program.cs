
namespace December.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //string sql = "Server=TEC-8220-LA0025;Database=DecemberDb;Trusted_Connection=true; Encrypt=true;" +
            //    "Trust Server Certifacte=true";
            string sql = "Server=localhost;Database=DecemberDb; Trusted_Connection=true; " +
                "Trust Server Certificate=true; Integrated Security=true; Encrypt=True;";
            builder.Services.AddDbContext<December.Infrastructure.DatabaseContext>(options =>
            options.UseSqlServer(sql));
            builder.Services.AddScoped<IPersonService, PersonService>();
            builder.Services.AddScoped<IPersonRepository, PersonRepository>();

            // builder.Services.AddDbContext<December.Infrastructure.DatabaseContext>(options =>
            //options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
