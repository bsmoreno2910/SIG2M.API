using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SIG2M.Dominio.Models.Autenticacao.AutenticacaoModels;

namespace SIG2M.Dominio.Interfaces.Servicos.Autenticacao
{
    public interface IServicoAutenticacao
    {
        Task<LoginResponse> Logar(LoginRequest @param);
    }
}
