using CodeChallenge.Models;
using CodeChallenge.Models.Dto;
using CodeChallenge.Service.IService;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

public class ClientController : Controller
{
    private readonly ILogger<ClientController> _logger;
    private readonly IClientService _service;

    public ClientController(ILogger<ClientController> logger, IClientService service)
    {
        _logger = logger;
        _service = service;
    }

    public async Task<IActionResult> Index(int? pageNumber)
    {
        int pageSize = 20;
        var clients = await _service.Findall();

        return View(Paging<ClientDto>.Create(clients, pageNumber ?? 1, pageSize));
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult<Client>> Create(ClientDto client)
    {
        try
        {
            if (client == null)
                return BadRequest();

            await _service.Create(client);

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            var errorViewModel = new ErrorViewModel { ErrorMessage = ex.Message };
            return View("Error", errorViewModel);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Filter(string? nome, string? email,
        string? fone, DateTime? data, bool? blocked)
    {
        try
        {
            var client = await _service.Filter(nome, email, fone, data, blocked);

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
    public async Task<IActionResult> Edit(int id)
    {        
        return View(await _service.FindById(id));
    }

    [HttpPost]
    public async Task<IActionResult> Edit (ClientDto client)
    {
        await _service.Update(client);

        return RedirectToAction(nameof(Index));
    }
}
