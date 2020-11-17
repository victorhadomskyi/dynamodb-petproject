namespace Application.Common.Handlers
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using Interfaces;

    public abstract class CommonHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        protected readonly IApplicationDbContext DbContext;

        protected CommonHandler(IApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
