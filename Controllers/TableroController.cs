using Microsoft.AspNetCore.Mvc;

namespace tl2_tp09_2023_Ragahe10.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class TableroController : ControllerBase
{
    private readonly ILogger<TableroController> _logger;
    private ITableroRepository tableroRepository;
    public TableroController(ILogger<TableroController> logger)
    {
        _logger = logger;
        tableroRepository = new TableroRepository();
    }
    [HttpPost]
    public ActionResult AddTablero(Tablero tablero){
        tableroRepository.AddTablero(tablero);
        return Ok();
    }

    [HttpGet]
    public ActionResult<List<Tablero>> GetAllTableros(){
        var tableros = tableroRepository.GetAllTableros();
        return Ok(tableros);
    }
}