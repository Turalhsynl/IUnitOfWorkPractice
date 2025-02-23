using Application.CQRS.Customers.Commands.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagementSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductRequest request)
    {
        return Ok(await _sender.Send(request));
    }
}
