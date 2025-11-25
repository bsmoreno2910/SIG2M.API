using SIG2M.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG2M.Dominio.Interfaces.Servicos.Grupos
{
    public interface IServicoGrupos
    { 
        Task<IEnumerable<Dominio.Entidades.Grupo>> ObterTodos(IDbConnection conn);
        Task<Dominio.Entidades.Grupo> ObterPorId(short codGrupo, IDbConnection conn);
        Task<Dominio.Entidades.Grupo> ObterPorNome(string nome, IDbConnection conn);
        Task<Dominio.Entidades.Grupo> Inserir(Dominio.Entidades.Grupo grupo, IDbConnection conn, IDbTransaction transaction = null);
        Task<Dominio.Entidades.Grupo> Atualizar(Dominio.Entidades.Grupo grupo, IDbConnection conn, IDbTransaction transaction = null); 
    }
}
