using ApiUsuarios.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface para definição dos métodos de serviço do domínio
    /// </summary>
    public interface IUsuarioDomainService
    {
        void CriarUsuario(Usuario usuario);
        Usuario Autenticar(string email, string senha);
        void RecuperarSenha(string email);


    }
}
