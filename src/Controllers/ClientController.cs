using CodeChallenge.Models;
using CodeChallenge.Models.Dto;
using CodeChallenge.Service.IService;
using CodeChallenge.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class ClientController : Controller
{
    private readonly ILogger<ClientController> _logger;
    private readonly IClientService _service;

    public ClientController(ILogger<ClientController> logger, IClientService service)
    {
        _logger = logger;
        _service = service;
    }

    [Authorize(Roles = Role.Admin)]
    public async Task<IActionResult> Index(int? pageNumber)
    {
        int pageSize = 20;
        var token = await HttpContext.GetTokenAsync("access_token");
        var clients = await _service.Findall(token);

        return View(Paging<ClientDto>.Create(clients, pageNumber ?? 1, pageSize));
    }

    [HttpGet]
    [Authorize(Roles = Role.Admin)]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    [Authorize(Roles = Role.Admin)]
    public async Task<ActionResult<Client>> Create(ClientDto client)
    {
        var token = await HttpContext.GetTokenAsync("access_token");
        try
        {
            if (client == null)
                return BadRequest();

            await _service.Create(client, token);

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            var errorViewModel = new ErrorViewModel { ErrorMessage = ex.Message };
            return View("Error", errorViewModel);
        }
    }

    [HttpGet]
    [Authorize(Roles = Role.Admin)]
    public async Task<IActionResult> Filter(string? nome, string? email,
        string? fone, DateTime? data, bool? blocked)
    {
        var token = await HttpContext.GetTokenAsync("access_token");
        try
        {
            var client = await _service.Filter(nome, email, fone, data, blocked, token);

            if (client != null)
                return View(client);

            return NotFound();
        }
        catch(Exception ex)
        {
            var errorViewModel = new ErrorViewModel { ErrorMessage = ex.Message };
            return View("Error", errorViewModel);
        }
    }

    [HttpGet]
    [Authorize(Roles = Role.Admin)]
    public async Task<IActionResult> Edit(int id)
    {
        var token = await HttpContext.GetTokenAsync("access_token");

        return View(await _service.FindById(id, token));
    }

    [HttpPost]
    [Authorize(Roles = Role.Admin)]
    public async Task<IActionResult> Edit (ClientDto client)
    {
        var token = await HttpContext.GetTokenAsync("access_token");
        await _service.Update(client, token);

        return RedirectToAction(nameof(Index));
    }
}
