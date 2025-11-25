using SIG2M.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace SIG2M.Dominio.Interfaces.Repositorios.Expedicao

{
    public interface IRepositorioExpedicao
    {
        // CRUD Básico
        Task<IEnumerable<Dominio.Entidades.Expedicao>> ObterTodosAsync(IDbConnection conn, IDbTransaction transaction = null);
        Task<Dominio.Entidades.Expedicao> ObterPorIdAsync(long lista, int contador, IDbConnection conn, IDbTransaction transaction = null);
        Task<IEnumerable<Dominio.Entidades.Expedicao>> ObterPorListaAsync(long lista, IDbConnection conn, IDbTransaction transaction = null);
        Task<IEnumerable<Dominio.Entidades.Expedicao>> ObterPorMaterialAsync(int codMaterial, IDbConnection conn, IDbTransaction transaction = null);
        Task<IEnumerable<Dominio.Entidades.Expedicao>> ObterPorSetorAsync(string sigla, IDbConnection conn, IDbTransaction transaction = null);
        Task<bool> InserirAsync(Dominio.Entidades.Expedicao expedicao, IDbConnection conn, IDbTransaction transaction = null);
        Task<bool> AtualizarAsync(Dominio.Entidades.Expedicao expedicao, IDbConnection conn, IDbTransaction transaction = null);
        Task<bool> ExcluirAsync(long lista, int contador, IDbConnection conn, IDbTransaction transaction = null);
    }
}
