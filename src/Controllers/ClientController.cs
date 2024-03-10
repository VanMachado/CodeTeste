﻿using CodeChallenge.Models;
using CodeChallenge.Service.IService;
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

    public async Task<IActionResult> Index(int? pageNumber)
    {
        int pageSize = 20;
        var clients = await _service.Findall();

        return View(Paging<Client>.Create(clients, pageNumber ?? 1, pageSize));
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult<Client>> Create(Client client)
    {
        if (client == null)
            return BadRequest();

        await _service.Create(client);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Filter(string? nome, string? email,
        string? fone, DateTime? data, bool? blocked)
    {
        var client = await _service.Filter(nome, email, fone, data, blocked);

        if (client != null)
            return View(client);

        return NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {        
        return View(await _service.FindById(id));
    }

    [HttpPost]
    public async Task<IActionResult> Edit (Client client)
    {
        await _service.Update(client);

        return RedirectToAction(nameof(Index));
    }
}
