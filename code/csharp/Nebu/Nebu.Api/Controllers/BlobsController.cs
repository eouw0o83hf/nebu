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
    public async Task<IActionResult> CreateBlob([FromRoute] Guid bucketId, [FromForm] BlobWriteModel b)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var ms = new MemoryStream((int)b.File!.Length);
        await b.File.CopyToAsync(ms);
        ms.Position = 0;

        var result = await _blobService.CreateBlob(bucketId, b.File.FileName, b.File.Length, ms);
        return Ok(result);
    }

    [HttpGet("{blobId}/file")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetBlobFile([FromRoute] Guid bucketId, [FromRoute] Guid blobId)
    {
        var result = await _blobService.GetBlobFile(bucketId, blobId);
        return File(result.Content, "application/octet-stream", result.Filename);
    }
}

