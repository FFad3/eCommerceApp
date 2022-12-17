namespace eCommerce.Application.Contracts.Infrastructure
{
    public interface ICurrentUserService
    {
        string? UserId { get; }
    }
}