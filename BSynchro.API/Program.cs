using BSynchro.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

#region Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddAutoMapping();
builder.Services.AddMediatRs();
#endregion

var app = builder.Build();

#region Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
//app.ApplyMigration(); 
#endregion

app.Run();
