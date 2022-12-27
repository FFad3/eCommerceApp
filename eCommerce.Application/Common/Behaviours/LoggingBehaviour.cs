using eCommerce.Application.Contracts.Infrastructure;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace eCommerce.Application.Common.Behaviours
{
    internal sealed class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
    {
        private readonly ILogger<LoggingBehaviour<TRequest>> _logger;
        private readonly ICurrentUserService _currentUserService;

        public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest>> logger, ICurrentUserService currentUserService)
        {
            _logger = logger;
            _currentUserService = currentUserService;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var userId = _currentUserService.UserId;
            string userName = string.Empty;

            //if (!string.IsNullOrEmpty(userId))
            //{
            //    throw new NotImplementedException("Add implementation of getting username");
            //}
            _logger.LogInformation("UserId:{@userId} > Request:{@requestName}  Payload:{@Request}",
            userId, requestName, request);
            return Task.CompletedTask;
        }
    }
}