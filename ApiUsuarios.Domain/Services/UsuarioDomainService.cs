using ApiUsuarios.Domain.Entities;
using ApiUsuarios.Domain.Interfaces.Repositories;
using ApiUsuarios.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Domain.Services
{
    public class UsuarioDomainService : IUsuarioDomainService
    {
        //atributo
        private readonly IUsuarioRepository? _usuarioRepository;

        //método construtor utilizado para inicializar o atributo
        public UsuarioDomainService(IUsuarioRepository? usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void CriarUsuario(Usuario usuario)
        {
            //verificar se o email informado já existe no banco de dados
            if (_usuarioRepository.Get(usuario.Email) != null)
            {
                throw new ArgumentException("O email informado já está cadastrado, tente outro.");
            }

            //criptogradar a senha do usuário
            usuario.Senha = EncriptarSenha(usuario.Senha);

            //gravar o usuario no banco de dados
            _usuarioRepository.Add(usuario);

        }
        public Usuario Autenticar(string email, string senha)
        {
            //criptografar a senha do usuário
            senha = EncriptarSenha(senha);

            //procurar o usuário através do email e da senha
            var usuario = _usuarioRepository.Get(email, senha);

            //verificar se o usuário foi encontrado
            if(usuario != null)
            {
                return usuario;
            }
            else
            {
                throw new ArgumentException("Acesso negado. Usuário inválido,");            }
        }

        public void RecuperarSenha(string email)
        {
            //procurar o usuário através do email
            var usuario = _usuarioRepository.Get(email);

            //verificar se o usuário foi encontrado
            if(usuario != null)
            {
                //falta fazer
            }
            else
            {
                throw new ArgumentException("Usuário não encontrado");
            }
        }

        //método para criptogracar a senha do usuário
        private string EncriptarSenha(string senha)
        {
            var hash = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(senha));
            return Convert.ToHexString(hash);
        }
    }
}
