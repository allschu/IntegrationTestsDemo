using MediatR;

namespace IntegrationTestsDemo.Application.Commands
{
    public class AddProductCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
        public required decimal Price { get; set; }
    }
}
