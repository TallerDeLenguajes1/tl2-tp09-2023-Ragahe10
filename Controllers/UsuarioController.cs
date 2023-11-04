using Microsoft.AspNetCore.Mvc;

namespace tl2_tp09_2023_Ragahe10.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly ILogger<UsuarioController> _logger;
    private IUsuarioRepository usuarioRepository;
    public UsuarioController(ILogger<UsuarioController> logger)
    {
        _logger = logger;
        usuarioRepository = new UsuarioRepository();
    }
    [HttpPost ("AddUsuario")]
    public ActionResult AddUsuario(Usuario usuario){
        usuarioRepository.AddUsuario(usuario);
        return Ok();
    }

    [HttpGet ("Usuario")]
    public ActionResult<List<Usuario>> GetAllUsuarios(){
        var usuarios = usuarioRepository.GetAllUsuarios();
        return Ok(usuarios);
    }
    [HttpGet ("Usuario/{id}")]
    public ActionResult<Usuario> GetUsuario(int id){
        var usuario = usuarioRepository.GetUsuario(id);
        return Ok(usuario);
    }
    [HttpPut ("Usuario/{id}/Nombre")]
    public ActionResult UpdateUSuario(int id, Usuario usuario){
        usuarioRepository.UpdateUsuario(id,usuario);
        return Ok();
    }

}