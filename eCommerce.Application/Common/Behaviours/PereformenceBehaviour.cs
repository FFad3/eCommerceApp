using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace eCommerce.Application.Common.Behaviours
{
    internal sealed class PereformenceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _logger;

        public PereformenceBehaviour(ILogger<TRequest> logger)
        {
            _timer = new Stopwatch();
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _timer.Start();
            var response = await next();
            _timer.Stop();

            var elapsedMilliseconds = _timer.Elapsed;
            var requestName = typeof(TRequest).Name;
            _logger.LogInformation("{request} | Execution time: {time}", requestName, elapsedMilliseconds);
            return response;
        }
    }
}