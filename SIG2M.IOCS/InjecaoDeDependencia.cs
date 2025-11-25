using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SIG2M.Dominio.Interfaces.Repositorios.Almoxarifado;
using SIG2M.Dominio.Interfaces.Repositorios.Autenticacao;
using SIG2M.Dominio.Interfaces.Repositorios.Expedicao;
using SIG2M.Dominio.Interfaces.Repositorios.Grupos;
using SIG2M.Dominio.Interfaces.Repositorios.Material;
using SIG2M.Dominio.Interfaces.Repositorios.SaldoEstoque;
using SIG2M.Dominio.Interfaces.Repositorios.Setor;
using SIG2M.Dominio.Interfaces.Servicos.Autenticacao;
using SIG2M.Dominio.Interfaces.Servicos.Conexao;
using SIG2M.Dominio.Interfaces.Servicos.Expedicao;
using SIG2M.Dominio.Interfaces.Servicos.Grupos;
using SIG2M.Dominio.Interfaces.Servicos.Material;
using SIG2M.Dominio.Interfaces.Servicos.SaldoEstoque;
using SIG2M.Dominio.Interfaces.Servicos.Setor;
using SIG2M.Repositorios;
using SIG2M.Repositorios.Autenticacao;
using SIG2M.Repositorios.Expedicao;
using SIG2M.Repositorios.Grupos;
using SIG2M.Repositorios.Material;
using SIG2M.Repositorios.SaldoEstoque;
using SIG2M.Repositorios.Setor;
using SIG2M.Servicos.Autenticacao;
using SIG2M.Servicos.Conexao;
using SIG2M.Servicos.Expedicao;
using SIG2M.Servicos.Grupos;
using SIG2M.Servicos.Material;
using SIG2M.Servicos.SaldoEstoque;
using SIG2M.Servicos.Setor;
using SIG2M.Servicos.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG2M.IOCS
{
    public static class InjecaoDeDependencia
    {
        /// <summary>
        /// Classe responsável pela configuração da injeção de dependência com seus diversos
        /// estados: "singleton","transient","scoped".
        /// </summary>
        /// <param name="servicos">IServiceCollection da solução</param>
        public static void ConfigurarServicos(this IServiceCollection servicos, IConfiguration configuracao)
        {
            #region [Singleton]
            servicos.ConfigurarDapper(configuracao);
            servicos.AddSingleton<IConfiguration>(configuracao);
            servicos.AddSingleton<JwtTokenService>();
            #endregion

            #region [Scoped]
            servicos.AddScoped<IServicoDeConexao, ServicoDeConexao>();
            #endregion
            #region [Transient]


            #region [Servicos]
            servicos.AddTransient<IServicoAutenticacao, ServicoAutenticacao>();  
            servicos.AddTransient<IServicoSaldoEstoque, ServicoSaldoEstoque>();
            servicos.AddTransient<IServicoExpedicoes, ServicoExpedicoes>();
            servicos.AddTransient<IServicoGrupos, ServicoGrupos>();
            servicos.AddTransient<IServicoSubGrupos, ServicoSubGrupos>();
            servicos.AddTransient<IServicoFamilias, ServicoFamilias>();
            servicos.AddTransient<IServicoMateriais, ServicoMateriais>();
            servicos.AddTransient<IServicoSetor, ServicoSetor>();
            #endregion

            #region [Repositorios]
            servicos.AddTransient<IRepositorioAutenticacao, RepositorioAutenticacao>(); 
            servicos.AddTransient<IRepositorioAlmoxarifado, RepositorioAlmoxarifado>(); 
            servicos.AddTransient<IRepositorioSaldoEstoque, RepositorioSaldoEstoque>(); 
            servicos.AddTransient<IRepositorioExpedicao, RepositorioExpedicao>(); 
            servicos.AddTransient<IRepositorioGrupo, RepositorioGrupo>(); 
            servicos.AddTransient<IRepositorioSubgrupo, RepositorioSubgrupo>(); 
            servicos.AddTransient<IRepositorioFamilia, RepositorioFamilia>(); 
            servicos.AddTransient<IRepositorioMaterial, RepositorioMaterial>(); 
            servicos.AddTransient<IRepositorioSetor, RepositorioSetor>(); 
            #endregion

            #endregion
        }
    }
}
