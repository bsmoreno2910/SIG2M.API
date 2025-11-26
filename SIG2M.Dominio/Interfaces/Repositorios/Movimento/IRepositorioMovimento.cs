using SIG2M.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG2M.Dominio.Interfaces.Repositorios.Movimento
{

    public interface IRepositorioMovimento
    {
        // CRUD Básico
        Task<IEnumerable<Dominio.Entidades.Movimento>> ObterTodosAsync(IDbConnection conn, IDbTransaction transaction = null);
        Task<Dominio.Entidades.Movimento> ObterPorIdAsync(int ano, int codMovimento, IDbConnection conn, IDbTransaction transaction = null);
        Task<IEnumerable<Dominio.Entidades.Movimento>> ObterPorDocumentoAsync(long lista, int contador, IDbConnection conn, IDbTransaction transaction = null);
        Task<int> ObterProximoIdAsync(int ano, IDbConnection conn, IDbTransaction transaction = null);
        Task<int> InserirAsync(Dominio.Entidades.Movimento movimento, IDbConnection conn, IDbTransaction transaction = null);
        Task<bool> AtualizarAsync(Dominio.Entidades.Movimento movimento, IDbConnection conn, IDbTransaction transaction = null);
        Task<bool> ExcluirAsync(int codMovimento, IDbConnection conn, IDbTransaction transaction = null);

    }
}
