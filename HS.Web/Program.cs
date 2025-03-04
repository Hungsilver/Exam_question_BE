using Exam_question_BE.HS.Core.DI;
using Exam_question_BE.HS.Core.Security;
using Exam_question_BE.HS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//tuan tu hoa. tranh truy van long 
builder.Services.AddMvc()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
// Add services to the container.
builder.Services.AddControllers(options =>
    {
        options.Filters.Add<HttpResponseExceptionFilter>();
    }
);
// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// add config swagger (authen,version)
builder.Services.AddSwaggerConfiguration();
builder.Services.AddSwaggerGen();
//add DI
builder.Services.AddRepositoriesCollection();
builder.Services.AddServicesCollection();
//config sqlserver
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services
    .AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(connectionString));

//open cors public 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});
//config autoMapper
builder.Services.AddAutoMapper(typeof(Program));
// Cấu hình JWT
builder.Services.AddJwtConfiguration(builder.Configuration);
builder.Services.AddHttpContextAccessor();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// Use CORS
app.UseCors("AllowAll");

app.UseAuthentication();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();
