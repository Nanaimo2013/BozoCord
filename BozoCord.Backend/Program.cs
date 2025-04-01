using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BozoCord.Core.Services;
using BozoCord.Core.WebSocket;
using BozoCord.Core.Services.Data;
using BozoCord.Core.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// Add JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? throw new InvalidOperationException()))
        };
    });

// Add WebSocket support
builder.Services.AddSignalR();

// Add DbContext
builder.Services.AddDbContext<BozoCordDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IServerService, ServerService>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IWebSocketConnectionManager, WebSocketConnectionManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapHub<WebSocketHub>("/ws");

// Ensure database is created and seeded
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BozoCordDbContext>();
    var created = db.Database.EnsureCreated();
    
    if (created)
    {
        // Add default roles
        var defaultRoles = new[]
        {
            new Role { Name = "Admin", Color = "#FF0000", ServerId = null },
            new Role { Name = "Moderator", Color = "#00FF00", ServerId = null },
            new Role { Name = "Member", Color = "#0000FF", ServerId = null }
        };
        db.Roles.AddRange(defaultRoles);
        
        // Add a test user
        var testUser = new User
        {
            Username = "TestUser",
            Email = "test@example.com",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("Test123!"),
            CreatedAt = DateTime.UtcNow,
            LastLoginAt = DateTime.UtcNow
        };
        db.Users.Add(testUser);
        
        // Add a test server
        var testServer = new Server
        {
            Name = "Test Server",
            Description = "A test server for development",
            OwnerId = testUser.Id,
            CreatedAt = DateTime.UtcNow
        };
        db.Servers.Add(testServer);
        
        // Add a test channel
        var testChannel = new Channel
        {
            Name = "general",
            Description = "General chat channel",
            ServerId = testServer.Id,
            CreatedAt = DateTime.UtcNow
        };
        db.Channels.Add(testChannel);
        
        db.SaveChanges();
    }
}

app.Run(); 