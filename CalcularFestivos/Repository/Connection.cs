using CalcularFestivos.Entities.Configuration;
using CalcularFestivos.Entities.Holidays;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace CalcularFestivos.Repository
{
    public class Connection : IConnection
    {
        private readonly IDbConnection db199;

        public Connection(IConfiguration configuration)
        {
            db199 = new SqlConnection(configuration.GetSection("ConnectionStrings").GetSection("ConexionBaseDeDatos").Value);
        }

        public async Task GuardarFestivos(DynamicParameters parameters)
        {
            await db199.QueryAsync("SP_GuardarFestivos", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task EliminarFestivos()
        {
            await db199.QueryAsync("SP_EliminarFestivos", commandType: CommandType.StoredProcedure);

        }

    }
}
