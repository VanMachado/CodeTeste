using CodeChallenge.Models;
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

    public async Task<IActionResult> Index()
    {
        var clients = await _service.Findall();

        return View(clients);
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
}
