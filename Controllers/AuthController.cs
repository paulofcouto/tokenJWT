using Microsoft.AspNetCore.Mvc;
using t.Models;
using t.Services;

namespace t.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        
        [HttpPost]
        public IActionResult Auth([FromServices] UsuarioService usuario, string nomeUsuario, string senha)
        {
            var usuarioCadastrado = usuario.ObterUsuario(nomeUsuario, senha);
            
            if(usuarioCadastrado != null)
            {
                var token = TokenService.GenerationToken(usuarioCadastrado);
                return Ok(token);
            }

            return BadRequest("Usuario ou senha inválido");
        }
    }
}
