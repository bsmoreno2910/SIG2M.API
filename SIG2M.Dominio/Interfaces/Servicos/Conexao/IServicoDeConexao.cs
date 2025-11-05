using SIG2M.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG2M.Dominio.Interfaces.Servicos.Conexao
{
    public interface IServicoDeConexao
    {
        IDbConnection Conectar(BaseDeDados conexao);
        Task<IDbConnection> ConectarAsync(BaseDeDados conexao, string nomeConexao = "", bool profiled = true);
        IDbConnection Conectar();
        Task<IDbConnection> ConectarAsync(string nomeConexao = "", bool profiled = true);
        string ConnectionString(BaseDeDados conexao = BaseDeDados.Suprimentos);
    }
}
