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
    public ActionResult<int> GetAllTareasByEstado(EstadoTarea estado){
        var tareas = tareaRepository.GetAllTareas();
        int cantidad = tareas.Count(t=>t.Estado==estado);
        return Ok(cantidad);
    }
    [HttpGet("Usuario/{id}")]
    public ActionResult<List<Usuario>> GetAllTareasByUsuario(int id){
        var tareas = tareaRepository.GetAllTareas().Where(t=>t.IdUsuarioAsignado==id);
        return Ok(tareas);
    }
    [HttpGet("Tablero/{id}")]
    public ActionResult<List<Usuario>> GetAllTareasByTablero(int id){
        var tareas = tareaRepository.GetAllTareas().Where(t => t.IdTablero==id);
        return Ok(tareas);
    }

}