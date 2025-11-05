using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SIG2M.Servicos.Utils
{
    public static class DapperConfig
    {
        public static void ConfigurarDapper(this IServiceCollection servicos, IConfiguration configuracao)
        {

            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
            SqlMapper.AddTypeHandler(new GenericArrayHandler<int>());
            SqlMapper.AddTypeHandler(new IntegerListHandler());
             
            var resolver = new CustomResolver();
            SimpleCRUD.SetTableNameResolver(resolver);
            SimpleCRUD.SetColumnNameResolver(resolver);
        }
        public class CustomResolver : SimpleCRUD.ITableNameResolver, SimpleCRUD.IColumnNameResolver
        {
            public string ResolveTableName(Type type)
            {
                // tenta localizar o atributo [Table("...")]
                var tableAttr = type.GetCustomAttribute<System.ComponentModel.DataAnnotations.Schema.TableAttribute>();

                // se existir, usa o nome definido nele; senão, usa o nome da classe
                var nomeTabela = tableAttr?.Name ?? string.Format("{0}", type.Name.ToLower());

                return nomeTabela.ToLowerInvariant();
            } 
            public string ResolveColumnName(PropertyInfo propertyInfo)
            {
                var columnAttr = propertyInfo.GetCustomAttribute<System.ComponentModel.DataAnnotations.Schema.ColumnAttribute>();
                var nomeColuna = columnAttr?.Name ?? propertyInfo.Name;
                return nomeColuna.ToLowerInvariant();
            }
        }
        private class GenericArrayHandler<T> : SqlMapper.TypeHandler<T[]>
        {
            public override void SetValue(IDbDataParameter parameter, T[] value)
            {
                parameter.Value = value;
            }

            public override T[] Parse(object value) => (T[])value;
        }
        private class IntegerListHandler : SqlMapper.TypeHandler<List<int>>
        {
            public override List<int> Parse(object value)
            {
                int[] typedValue = (int[])value;
                return typedValue?.ToList();
            }

            public override void SetValue(IDbDataParameter parameter, List<int> value)
            {
                parameter.Value = value;
            }
        } 

    }

}
