using eCommerce.Application.Contracts.Infrastructure;
using System.Security.Claims;
using System.Text.Json;

namespace eCommerce.Api.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ILogger<CurrentUserService> _logger;

        public CurrentUserService(IHttpContextAccessor contextAccessor, ILogger<CurrentUserService> logger)
        {
            _contextAccessor = contextAccessor;
            _logger = logger;
        }

        public string CurrentUser()
        {
            var item = _contextAccessor.HttpContext?.User;
            var json = JsonSerializer.Serialize(item);
            _logger.LogInformation("Current user info:{json}", json);
            return _contextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier) ?? "UNKNOWN";
        }
    }
}