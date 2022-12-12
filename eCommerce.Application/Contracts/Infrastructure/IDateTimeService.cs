namespace eCommerce.Application.Contracts.Infrastructure
{
    public interface IDateTimeService
    {
        /// <summary>
        /// Get current system date
        /// </summary>
        DateTime Now { get; }
    }
}