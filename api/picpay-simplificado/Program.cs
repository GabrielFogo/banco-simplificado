using picpay_simplificado.Configs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCustomAuthentication(builder.Configuration);
builder.Services.AddCustomMvc();
builder.Services.AddCustomDbContext(builder.Configuration);
builder.Services.AddCustomSwagger();
builder.Services.AddCustomDependencies();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();