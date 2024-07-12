using Geometry.Application.Triangles.GetArea;
using Geometry.Application.Triangles.CreateTriangle;
using Geometry.Application.Triangles.GetTriangle;
using Geometry.Application.Triangles.IsRight;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Geometry.Api.Controllers.Triangles;

[ApiController]
[Route("api/triangles")]
public class TrianglesController : ControllerBase
{
    private readonly ISender _sender;

    public TrianglesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("gettriangle{id:Guid}")]
    public async Task<ActionResult<TriangleResponse>> GetTriangle(
        Guid id,
        CancellationToken cancellationToken)
    {
        var query = new GetTriangleQuery(id);
        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateTriangle(
        TriangleModelForCreation model,
        CancellationToken cancellationToken)
    {
        var command = new CreateTriangleQuery(model.SideA, model.SideB, model.SideC);
        var triangleId = await _sender.Send(command, cancellationToken);

        return Ok(triangleId);
    }

    [HttpGet("isright{id:Guid}")]
    public async Task<ActionResult<bool>> IsRight(
        Guid id,
        CancellationToken cancellationToken)
    {
        var query = new IsRightTriangleQuery(id);
        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpGet("area{id:Guid}")]
    public async Task<ActionResult<double>> GetArea(
        Guid id,
        CancellationToken cancellationToken)
    {
        var query = new GetAreaQuery(id);
        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

}
