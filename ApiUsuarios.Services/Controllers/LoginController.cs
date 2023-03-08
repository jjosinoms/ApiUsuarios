using ApiUsuarios.Services.Models;
using ApiUsuarios.Services.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsuarios.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(LoginPostModel model)
        {
            var tokenCreator = new TokenCreator();
            if(model.Email.Equals(Usuario.Email) && model.Senha.Equals(Usuario.Senha))
            {
                return StatusCode(200, new
                {
                    mensagem = "Usuário autenticado com sucesso",
                    usuario = new
                    {
                        Usuario.IdUsuario,
                        Usuario.Nome,
                        Usuario.Email
                    },
                    token = tokenCreator.GenerateToken(Usuario.Email),
                });
            }
            else
            {
                return StatusCode(401, new { mensagem = "Acesso negado. Usuário inválido." });
            }
            
            return Ok();

        }


        public class Usuario
        {
            public static Guid IdUsuario { get => Guid.NewGuid(); }
            public static string? Nome { get => "Usuario administrador"; }
            public static string? Email { get => "jjosinoms@gmail.com"; }
            public static string? Senha { get => "@admin123"; }
        }
    }
}
