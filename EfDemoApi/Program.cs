var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

// Required by UseEndpoints middleware
app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    // Adds endpoints for controllers actions without specifying routes which will specified by attributes in controllers
    endpoints.MapControllers();
});

app.Run();
