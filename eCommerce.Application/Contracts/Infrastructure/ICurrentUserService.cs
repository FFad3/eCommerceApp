namespace eCommerce.Application.Contracts.Infrastructure
{
    public interface ICurrentUserService
    {
        Task<string?> CurrentUser { get; }
    }
}