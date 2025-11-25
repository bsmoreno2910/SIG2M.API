using System.Data;

namespace SIG2M.Dominio.Interfaces.Repositorios.Almoxarifado
{
    public interface IRepositorioAlmoxarifado
    {
        // CRUD Básico
        Task<SIG2M.Dominio.Entidades.Almoxarifado> ObterPorIdAsync(string codAlmox, IDbConnection conn, IDbTransaction transaction = null);
        Task<SIG2M.Dominio.Entidades.Almoxarifado> ObterPorNomeAsync(string nome, IDbConnection conn, IDbTransaction transaction = null);
        Task<string> InserirAsync(SIG2M.Dominio.Entidades.Almoxarifado almoxarifado, IDbConnection conn, IDbTransaction transaction = null);
        Task<bool> AtualizarAsync(SIG2M.Dominio.Entidades.Almoxarifado almoxarifado, IDbConnection conn, IDbTransaction transaction = null);
        Task<bool> ExcluirAsync(string codAlmox, IDbConnection conn, IDbTransaction transaction = null);
    }
}
