using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BozoCord.Core.Services;
using BozoCord.Core.Models;

namespace BozoCord.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ServerController : ControllerBase
{
    private readonly IServerService _serverService;

    public ServerController(IServerService serverService)
    {
        _serverService = serverService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateServer([FromBody] CreateServerRequest request)
    {
        try
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var server = await _serverService.CreateServerAsync(request, userId);
            return Ok(server);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetUserServers()
    {
        try
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var servers = await _serverService.GetUserServersAsync(userId);
            return Ok(servers);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("{serverId}")]
    public async Task<IActionResult> GetServer(string serverId)
    {
        try
        {
            var server = await _serverService.GetServerByIdAsync(serverId);
            if (server == null)
            {
                return NotFound();
            }

            return Ok(server);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("{serverId}/channels")]
    public async Task<IActionResult> CreateChannel(string serverId, [FromBody] CreateChannelRequest request)
    {
        try
        {
            var channel = await _serverService.CreateChannelAsync(serverId, request);
            return Ok(channel);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("{serverId}/channels")]
    public async Task<IActionResult> GetServerChannels(string serverId)
    {
        try
        {
            var channels = await _serverService.GetServerChannelsAsync(serverId);
            return Ok(channels);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
} 