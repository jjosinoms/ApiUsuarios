using System.ComponentModel.DataAnnotations;

namespace ApiUsuarios.Services.Models
{
    public class LoginPostModel
    {
        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email do usuári.")]
        public string? Email { get; set; }
        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(20, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a senha do usuário")]
        public string? Senha { get; set; }
    }
}
