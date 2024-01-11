using Microsoft.EntityFrameworkCore;
using UniverMnagment.Data;

var builder = WebApplication.CreateBuilder(args);

// Remove the AddJsonOptions that sets the ReferenceHandler to Preserve
// Or comment it out if you might want to re-enable it later
// builder.Services.AddControllers().AddJsonOptions(options =>
// {
//     options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
// });

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.UseCors(builder =>
    builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

app.MapControllers();

app.Run();
