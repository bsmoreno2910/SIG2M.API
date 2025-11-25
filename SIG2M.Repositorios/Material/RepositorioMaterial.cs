using Dapper;
using SIG2M.Dominio.Entidades;
using SIG2M.Dominio.Interfaces.Repositorios.Material;
using System.Data;

namespace SIG2M.Repositorios.Material
{
    public class RepositorioMaterial : IRepositorioMaterial
    {

        public async Task<IEnumerable<Dominio.Entidades.Material>> ObterTodosAsync(IDbConnection conn, IDbTransaction transaction = null)
        {
            var materiais = await conn.GetListAsync<Dominio.Entidades.Material>(transaction);
            foreach (var material in materiais)
                material.Descricao = await conn.GetAsync<tbdDescricao>(material.CodMaterial, transaction);
            return materiais;
        }

        public async Task<Dominio.Entidades.Material> ObterPorIdAsync(int codMaterial, IDbConnection conn, IDbTransaction transaction = null)
        {
            var material = await conn.GetAsync<Dominio.Entidades.Material>(codMaterial, transaction);
            if (material != default)
                material.Descricao = await conn.GetAsync<tbdDescricao>(material.CodMaterial, transaction);
            return material;
        }

        public async Task<Dominio.Entidades.Material> ObterPorNomeAsync(string nome, IDbConnection conn, IDbTransaction transaction = null)
        {
            string commandText = "SELECT * FROM material WHERE nome = @nome";
            var material = await conn.QueryFirstOrDefaultAsync<Dominio.Entidades.Material>(commandText, new { nome }, transaction);
            if (material != default)
                material.Descricao = await conn.GetAsync<tbdDescricao>(material.CodMaterial, transaction);
            return material;
        }

        public async Task<IEnumerable<Dominio.Entidades.Material>> ObterPorGrupoAsync(short codGrupo, IDbConnection conn, IDbTransaction transaction = null)
        {
            var materiais = await conn.GetListAsync<Dominio.Entidades.Material>(new { CodGrupo = codGrupo }, transaction);
            foreach (var material in materiais)
                material.Descricao = await conn.GetAsync<tbdDescricao>(material.CodMaterial, transaction);
            return materiais;
        }

        public async Task<IEnumerable<Dominio.Entidades.Material>> ObterPorSubGrupoAsync(short codSubGrupo, IDbConnection conn, IDbTransaction transaction = null)
        {
            var materiais = await conn.GetListAsync<Dominio.Entidades.Material>(new { CodSubgrupo = codSubGrupo }, transaction); 
            foreach (var material in materiais)
                material.Descricao = await conn.GetAsync<tbdDescricao>(material.CodMaterial, transaction);
            return materiais;
        }

        public async Task<IEnumerable<Dominio.Entidades.Material>> ObterPorFamiliaAsync(short codFamilia, IDbConnection conn, IDbTransaction transaction = null)
        {
            var materiais = await conn.GetListAsync<Dominio.Entidades.Material>(new { CodFamilia = codFamilia }, transaction);
            foreach (var material in materiais)
                material.Descricao = await conn.GetAsync<tbdDescricao>(material.CodMaterial, transaction);
            return materiais;
        }


        public async Task<int> InserirAsync(Dominio.Entidades.Material material, IDbConnection conn, IDbTransaction transaction = null)
        {
            var codMaterial = await conn.InsertAsync<int, Dominio.Entidades.Material>(material, transaction);
            var codMaterialDescricao = await conn.InsertAsync<int, Dominio.Entidades.tbdDescricao>(material.Descricao, transaction);
            if (codMaterial > 0 && codMaterialDescricao > 0)
                return codMaterial;
            throw new Exception("Falha ao Inserir");
        }

        public async Task<bool> AtualizarAsync(Dominio.Entidades.Material material, IDbConnection conn, IDbTransaction transaction = null)
        {
            var resultMaterial = await conn.UpdateAsync<Dominio.Entidades.Material>(material, transaction) > 0;
            var resultMaterialDescricao = await conn.UpdateAsync<Dominio.Entidades.tbdDescricao>(material.Descricao, transaction) > 0;

            if (resultMaterial && resultMaterialDescricao)
                return true;
            else
                return false;
        }

        public async Task<bool> ExcluirAsync(int codMaterial, IDbConnection conn, IDbTransaction transaction = null)
        {
            var resultMaterial = await conn.DeleteAsync<Dominio.Entidades.Material>(codMaterial, transaction) > 0;
            var resultMaterialDescricao = await conn.DeleteAsync<Dominio.Entidades.tbdDescricao>(codMaterial, transaction) > 0;
            if (resultMaterial && resultMaterialDescricao)
                return true;
            else
                return false;
        }

    }
}
