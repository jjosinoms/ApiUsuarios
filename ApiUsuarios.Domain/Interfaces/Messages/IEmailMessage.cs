using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Domain.Interfaces.Messages
{
    /// <summary>
    /// Interface para definir os métodos de envio de mensagens do sistema
    /// </summary>
    public interface IEmailMessage
    {
        /// <summary>
        /// Método para realizar um envio de email
        /// </summary>
        /// <param name="to">Email do destinatário da mensagem</param>
        /// <param name="subject">Assunto da mensagem</param>
        /// <param name="body">Corpo da mensagem</param>
        void Send(string to, string subject, string body);
    }
}
