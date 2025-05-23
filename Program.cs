

using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using scoreoracle_backend.Interfaces;
using scoreoracle_backend.Repositories;
using scoreoracle_backend.Services;
using Supabase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration
    .AddJsonFile("appsettings.json", optional: true)
    .AddUserSecrets<Program>()
    .AddEnvironmentVariables();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddSingleton(provider => {
    var cfg = provider.GetRequiredService<IConfiguration>();
    var url = cfg["Supabase:Url"];
    var key = cfg["Supabase:ServiceRoleKey"];

    if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(key))
        throw new Exception("Missing Supabase credentials!");

    var client = new Supabase.Client(url, key, 
        new SupabaseOptions { AutoConnectRealtime = true });
    client.InitializeAsync().Wait();
    return client;
});


builder.Services
  .AddControllers()
  .AddJsonOptions(opts =>
  {
      // ← this makes ASP.NET accept both "Member"/"Admin" *and* 0/1 for GroupRole
      opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
      opts.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
  });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<UserService>();

builder.Services.AddScoped<ISportRepository, SportRepository>();
builder.Services.AddScoped<SportService>();

builder.Services.AddScoped<ILeagueRepository, LeagueRepository>();
builder.Services.AddScoped<LeagueService>();

builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<TeamService>();

builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<GameService>();

builder.Services.AddScoped<IGroupRepository, GroupRepository>();
builder.Services.AddScoped<GroupService>();

builder.Services.AddScoped<IGroupMemberRepository, GroupMemberRepository>();
builder.Services.AddScoped<GroupMemberService>();

builder.Services.AddScoped<IPickRepository, PickRepository>();
builder.Services.AddScoped<PickService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowFrontend");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
