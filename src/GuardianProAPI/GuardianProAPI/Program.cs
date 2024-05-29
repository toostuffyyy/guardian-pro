var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(p=>p.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes=true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("WebService", policyBuilder =>
    {
        policyBuilder.WithOrigins("https://localhost:5001").AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("WebService");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();