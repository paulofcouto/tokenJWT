using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using t.Models;
using t.Services;

namespace t.Controllers;

[ApiController]
[Route("api/v1/usuario")]
public class UsuarioController : ControllerBase
{
    private readonly UsuarioService _usuariosService;

    public UsuarioController(UsuarioService usuariosService)
    {
        _usuariosService = usuariosService;
    }

    [Authorize]
    [HttpGet]
    [Route("/ObterTodosUsuarios")]
    public List<Usuario> ObterUsuarios([FromServices] UsuarioService usuario)
    {
        return _usuariosService.ObterUsuarios();
    }

}

