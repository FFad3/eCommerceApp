using eCommerce.Application.Contracts.Infrastructure;

namespace eCommerce.Infrastructure.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Now => DateTime.UtcNow;
    }
}