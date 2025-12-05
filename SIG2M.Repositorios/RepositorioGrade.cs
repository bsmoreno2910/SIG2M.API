using SIG2M.Dominio.Entidades;
using SIG2M.Dominio.Interfaces.Repositorios.Grade;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG2M.Repositorios
{
    public class RepositorioGrade : IRepositorioGrade
    {
        public Task<bool> AtualizarStatusAsync(Grade grade, IDbConnection conn, IDbTransaction transaction = null)
        {
            throw new NotImplementedException();
        }

        //public Task<bool> AtualizarStatusAsync(Grade grade, IDbConnection conn, IDbTransaction transaction = null)
        //{
        //    string commandText = @" UPDATE grade
        //                            SET status='A'
        //                            where sigla = @sigla
        //                              AND cod_material = @cod_material
        //                              AND qtde = @qtde
        //                              AND funci = @funci
        //                              AND obs = @obs
        //                              AND status = @status
        //                              and tipo = @tipo
        //                              AND data = @data;";




        //}

        public Task<IEnumerable<Grade>> PedidosPendentesAsync(IDbConnection conn, IDbTransaction transaction = null)
        {
            throw new NotImplementedException();
        }
    }
}
