using eCommerce.Application.Contracts.Infrastructure;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Text.Json;

namespace eCommerce.Application.Common.Behaviours
{
    internal sealed class AppLoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<AppLoggingBehaviour<TRequest, TResponse>> _logger;
        private readonly ICurrentUserService _currentUserService;

        public AppLoggingBehaviour(ILogger<AppLoggingBehaviour<TRequest, TResponse>> logger, ICurrentUserService currentUserService)
        {
            _logger = logger;
            _currentUserService = currentUserService;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var requestType = typeof(TRequest);
            var currentUser = await _currentUserService.CurrentUser;
            var requestName = requestType.Name;
            var requestId = requestType.GUID;
            var requestJson = JsonSerializer.Serialize(request);

            _logger.LogInformation("USER:{user} | Request: {requestName} Json: {payload}", currentUser, requestName, requestJson);
            var timer = new Stopwatch();
            timer.Start();
            var response = await next();
            timer.Stop();
            _logger.LogInformation("End Request GUID:{requestId}, request name:{requestName}, total request time:{time}ms", requestId, requestName, timer.ElapsedMilliseconds);
            return response;
        }
    }
}