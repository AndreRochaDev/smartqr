var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins(
                "http://localhost:3000",    // React default
                "http://localhost:3001",    // React alternative
                "http://localhost:4200",    // Angular default
                "http://localhost:5173",    // Vite default
                "http://localhost:8080",    // Vue CLI default
                "http://localhost:8081",    // Alternative port
                "https://localhost:3000",   // HTTPS versions
                "https://localhost:3001",
                "https://localhost:4200",
                "https://localhost:5173",
                "https://localhost:8080",
                "https://localhost:8081"
            )
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
    
    // More permissive policy for development
    options.AddPolicy("DevelopmentCors", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    
    // Enable Swagger UI
    app.UseSwagger();
    app.UseSwaggerUI();
    
    // Use more permissive CORS in development
    app.UseCors("DevelopmentCors");
}
else
{
    // Use restrictive CORS in production
    app.UseCors("AllowLocalhost");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
