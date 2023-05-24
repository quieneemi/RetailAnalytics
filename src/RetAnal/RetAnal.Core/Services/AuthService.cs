using Microsoft.EntityFrameworkCore;
using RetAnal.Core.Interfaces;
using RetAnal.Data;

namespace RetAnal.Core.Services;

public class AuthService : IAuthService
{
    private readonly PostgresContext _dbContext;
    private readonly ILoggerService _logger;

    public AuthService(PostgresContext postgres, ILoggerService logger)
    {
        _dbContext = postgres;
        _logger = logger;
    }

    public async Task<string> LoginAsync(string username, string password)
    {
        await _logger.InfoAsync($"LoginAsync(string username, string password): username = {username}, password = {password}");
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(x => x.UserName.Equals(username) && x.UserPassword.Equals(password));

        if (user is not null) return user.UserRole;

        await _logger.WarningAsync("Incorrect username or password");
        return string.Empty;
    }
}