using Codere.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Codere.Attribute;

[ApiController]
[Route("api/admin")]
public class AdminController : ControllerBase
{
    private readonly ITvMazeService _tvMazeService;

    public AdminController(ITvMazeService tvMazeService)
    {
        _tvMazeService = tvMazeService;
    }

    [HttpPost("run-job")]
    [ApiKeyAuthorize] 
    public async Task<IActionResult> RunJob()
    {
        await _tvMazeService.FetchAndStoreShowsAsync();
        return Ok("Job executed successfully.");
    }

    [HttpGet()]
    public async Task<IActionResult> ObtenerShow()
    {
        await _tvMazeService.ObtenerShow();
        return Ok();
    }
}
