using Application.Common.Interfaces;
using Infrastructure;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Remove circular dependency
builder.Services.AddControllers().AddJsonOptions(options =>
options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IGuestRepository, GuestRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();

builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer("name=DefaultConnection"));

builder.Services.AddMediatR(typeof(IAssemblyMarker));
builder.Services.AddAutoMapper(typeof(IAssemblyMarker));

//var mappingConfig = new MapperConfiguration(mc =>
//{
//   // mc.AddProfile(new BookingProfile());
//   // mc.AddProfile(new GuestProfile());
//    mc.AddProfile<RoomProfile>();
//   // mc.AddProfile(new RoomTypeProfile());
//});

//IMapper mapper = mappingConfig.CreateMapper();
//services.AddSingleton(mapper);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();