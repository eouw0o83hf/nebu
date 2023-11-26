using Microsoft.AspNetCore.Mvc;
using Nebu.Api.Models.Buckets;

namespace Nebu.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BucketsController(IBucketService _bucketService) : ControllerBase
{
    [HttpGet]
    public Task<IEnumerable<BucketReadModel>> ListBuckets([FromHeader] Guid userId)
    {
        return _bucketService.ListBuckets(userId);
    }

    [HttpPost]
    [ProducesResponseType<BucketReadModel>(StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateBucket([FromHeader] Guid userId, [FromBody] BucketWriteModel b)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _bucketService.CreateBucket(userId, b);
        return Ok(result);
    }
}

