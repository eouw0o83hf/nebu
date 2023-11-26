using Microsoft.AspNetCore.Mvc;
using Nebu.Api.Models.Blobs;

namespace Nebu.Api.Controllers;

[ApiController]
[Route("api/buckets/{bucketId}/[controller]")]
public class BlobsController(IBlobService _blobService) : ControllerBase
{
    [HttpGet]
    public Task<IEnumerable<BlobReadModel>> ListBlobs([FromRoute] Guid bucketId)
    {
        return _blobService.ListBlobs(bucketId);
    }

    [HttpPost]
    [ProducesResponseType<BlobReadModel>(StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateBlob([FromRoute] Guid bucketId, [FromBody] BlobWriteModel b)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _blobService.CreateBlob(bucketId, b);
        return Ok(result);
    }
}

