using CalcularFestivos.Entities.Configuration;
using CalcularFestivos.Entities.Holidays;
using Dapper;

namespace CalcularFestivos.Repository
{
    public interface IConnection
    {
        Task GuardarFestivos(DynamicParameters parametros);
        Task EliminarFestivos();
    }
}
