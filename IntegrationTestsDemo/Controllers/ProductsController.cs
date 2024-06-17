using IntegrationTestsDemo.Application.Commands;
using IntegrationTestsDemo.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationTestsDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IMediator _mediator;

        public ProductsController(ILogger<ProductsController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<ProductDto>> Get(CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Getting all products");



            return Ok();
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<ProductDto>> GetById(Guid productId, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Getting product by id {productId}", productId);

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> AddProduct(AddProductRequest request, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Adding product {@request}", request);

            var command = new AddProductCommand { Name = request.Name, Price = request.Price };

            var productId = await _mediator.Send(command, cancellationToken);

            return Created($"products/{productId}", productId);
        }
    }
}
