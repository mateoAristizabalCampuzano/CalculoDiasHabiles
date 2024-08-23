using CalcularFestivos.Bussiness.Holidays;
using CalcularFestivos.Entities.Configuration;
using CalcularFestivos.Entities.Holidays;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalcularFestivos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HolidaysController : ControllerBase
    {
        private readonly IHolidaysBussiness _HolidaysBussiness;

        public HolidaysController(IHolidaysBussiness HolidaysBussiness) 
        {
            _HolidaysBussiness = HolidaysBussiness;
        }

        [HttpGet("ObtenerFestivos")]
        public async Task<ResponseE<HolidaysEntities>> GetHolidays()
        {
            ResponseE<HolidaysEntities> result = await _HolidaysBussiness.ConsultarProveedorFestivos();
            return result;
        }
    }
}
