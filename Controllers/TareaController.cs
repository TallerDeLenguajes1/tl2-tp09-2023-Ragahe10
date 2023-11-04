using Microsoft.AspNetCore.Mvc;

namespace tl2_tp09_2023_Ragahe10.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class TareaController : ControllerBase
{
    private readonly ILogger<TareaController> _logger;
    private ITareaRepository tareaRepository;
    public TareaController(ILogger<TareaController> logger)
    {
        _logger = logger;
        tareaRepository = new TareaRepository();
    }
    [HttpPost]
    public ActionResult AddTarea(Tarea tarea){
        tareaRepository.AddTarea(tarea);
        return Ok();
    }
    [HttpPut ("{id}")]
    public ActionResult UpdateUSuario(int id, Tarea tarea){
        tareaRepository.UpdateTarea(id,tarea);
        return Ok();
    }
    [HttpPut ("{id}/Estado/{estado}")]
    public ActionResult UpdateEstadoTarea(int id, EstadoTarea estado){
        tareaRepository.UpdateEstadoTarea(id,estado);
        return Ok();
    }
    [HttpDelete ("{id}")]
    public ActionResult DeleteTarea(int id){
        tareaRepository.DeleteTarea(id);
        return Ok();
    }
    [HttpGet("{estado}")]
    public ActionResult<List<Usuario>> GetAllTareasByEstado(EstadoTarea estado){
        var usuarios = tareaRepository.GetAllTareasByEstado(estado);
        return Ok(usuarios);
    }
    [HttpGet("Tablero/{id}")]
    public ActionResult<List<Usuario>> GetAllTareasByUsuario(int id){
        var usuarios = tareaRepository.GetAllTareasByUsuario(id);
        return Ok(usuarios);
    }
    [HttpGet("Tablero/{id}")]
    public ActionResult<List<Usuario>> GetAllTareasByTablero(int id){
        var usuarios = tareaRepository.GetAllTareasByTablero(id);
        return Ok(usuarios);
    }

}