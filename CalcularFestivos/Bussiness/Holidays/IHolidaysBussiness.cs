using CalcularFestivos.Entities.Configuration;
using CalcularFestivos.Entities.Holidays;

namespace CalcularFestivos.Bussiness.Holidays
{
    public interface IHolidaysBussiness
    {
        Task<ResponseE<HolidaysEntities>> ConsultarProveedorFestivos();
    }
}
