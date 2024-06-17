using IntegrationTestsDemo.Infrastructure;
using MediatR;
using Microsoft.Extensions.Logging;

namespace IntegrationTestsDemo.Application.Commands
{
    public class AddProductCommandHandler(ILogger<AddProductCommandHandler> logger) : IRequestHandler<AddProductCommand, Guid>
    {
        //, BoxwiseDbContext context

        public async Task<Guid> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Adding product {@request}", request);

            //var zones = await context.Zones.FindAsync(2, cancellationToken);
            //add product to the database

            return Guid.NewGuid();
            //return Task.FromResult(Guid.NewGuid());
        }
    }
}
