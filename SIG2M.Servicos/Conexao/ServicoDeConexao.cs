using Microsoft.Extensions.Configuration;
using SIG2M.Dominio.Enums;
using SIG2M.Dominio.Interfaces.Servicos.Conexao;
using SIG2M.Servicos.Criptografia;
using System.Data;
using MySqlConnector;

namespace SIG2M.Servicos.Conexao
{
    public class ServicoDeConexao : IServicoDeConexao
    {
        private readonly IConfiguration _configuracao;

        public ServicoDeConexao(IConfiguration configuracao)
        {
            _configuracao = configuracao;
        }

        private IDbConnection Conectar(MySqlConnection conn)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            return conn;
        }

        private async Task<IDbConnection> ConectarAsync(MySqlConnection conn, bool profiled = true)
        {
            if (conn.State != ConnectionState.Open)
            {
                await conn.OpenAsync();
            }

            if (!profiled)
            {
                return conn;
            }

            return conn;
        }

        public IDbConnection Conectar(BaseDeDados conexao)
        {
            string stringDeConexao =
                ServicoDeCriptografia.Descriptografar(_configuracao.GetConnectionString(conexao.ToString()));
            
            MySqlConnectionStringBuilder connectionString = new MySqlConnectionStringBuilder(stringDeConexao); 
            connectionString.Pooling = false;
            connectionString.ConnectionLifeTime = 1024;
            connectionString.ConnectionTimeout = 1024;
            MySqlConnection connection = new MySqlConnection(connectionString.ToString());
            return Conectar(connection);
        }

        public IDbConnection Conectar()
        {
            return Conectar(BaseDeDados.Suprimentos);
        }

        public async Task<IDbConnection> ConectarAsync(BaseDeDados conexao, string nomeConexao = "", bool profiled = true)
        {
            string stringDeConexao =
                ServicoDeCriptografia.Descriptografar(_configuracao.GetConnectionString(conexao.ToString()));

            MySqlConnectionStringBuilder connectionString = new MySqlConnectionStringBuilder(stringDeConexao);
            connectionString.Pooling = false;
            connectionString.ConnectionLifeTime = 1024;
            connectionString.ConnectionTimeout = 1024;
            MySqlConnection connection = new MySqlConnection(connectionString.ToString());
            return await ConectarAsync(connection, profiled);
        }

        public async Task<IDbConnection> ConectarAsync(string nomeConexao = "", bool profiled = true)
        {
            return await ConectarAsync(BaseDeDados.Suprimentos, nomeConexao, profiled);
        }

        public string ConnectionString(BaseDeDados conexao = BaseDeDados.Suprimentos) =>
            ServicoDeCriptografia.Descriptografar(_configuracao.GetConnectionString(conexao.ToString()));
         
    }
}
