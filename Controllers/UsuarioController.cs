using Microsoft.AspNetCore.Mvc;

namespace tl2_tp09_2023_Ragahe10.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly ILogger<UsuarioController> _logger;
    private IUsuarioRepository usuarioRepository;
    public UsuarioController(ILogger<UsuarioController> logger)
    {
        _logger = logger;
        usuarioRepository = new UsuarioRepository();
    }
    [HttpPost (Name = "AddUsuario")]
    public ActionResult AddUsuario(Usuario usuario){
        usuarioRepository.AddUsuario(usuario);
        return Ok();
    }

    [HttpGet (Name = "Usuario")]
    public ActionResult<List<Usuario>> GetAllUsuarios(){
        var usuarios = usuarioRepository.GetAllUsuarios();
        return Ok(usuarios);
    }
    [HttpGet (Name = "Usuario/{id}")]
    public ActionResult GetUsuario(int idUsuario){
        var usuario = usuarioRepository.GetUsuario(idUsuario);
        return Ok(usuario);
    }
}