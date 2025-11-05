using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG2M.Dominio.Models.Autenticacao
{
    public class AutenticacaoModels
    {
        public class LoginRequest
        {
            public string Login { get; set; } = string.Empty;
            public string Password { get; set; }
        }
        public class LoginResponse
        {
            public string Token { get; set; } = string.Empty;
            public string Username { get; set; } = string.Empty; 
            public DateTime ExpiresIn { get; set; }
        }
        public class ErrorResponse
        {
            public string Error { get; set; } = string.Empty;
            public string Message { get; set; } = string.Empty;
        }
        public class MessageResponse
        {
            public string Message { get; set; } = string.Empty;
        }
    }
}
