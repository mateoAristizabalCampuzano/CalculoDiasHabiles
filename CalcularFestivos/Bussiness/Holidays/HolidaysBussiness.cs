using CalcularFestivos.Entities.Configuration;
using CalcularFestivos.Entities.Holidays;
using System.Net.Http.Headers;
using System;
using CalcularFestivos.Repository;
using Dapper;

namespace CalcularFestivos.Bussiness.Holidays
{
    public class HolidaysBussiness : IHolidaysBussiness
    {
        private string URLAPI;
        private readonly string pais;
        private readonly string anio;
        private readonly string ApiKey;
        private readonly IConnection _db;

        public HolidaysBussiness(IConfiguration configuration, IConnection connetion)
        {
            _db = connetion;
            URLAPI = configuration.GetSection("ConexionFestivosAPI").GetSection("URL").Value;
            pais = configuration.GetSection("ConexionFestivosAPI").GetSection("pais").Value;
            anio = configuration.GetSection("ConexionFestivosAPI").GetSection("anio").Value;
            ApiKey = configuration.GetSection("ConexionFestivosAPI").GetSection("ApiKey").Value;
        }

        public async Task<ResponseE<HolidaysEntities>> ConsultarProveedorFestivos()
        {
            URLAPI += $"?api_key={ApiKey}&country={pais}&year={anio}";
            HolidaysEntities festivos = new HolidaysEntities();
            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri(URLAPI);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync(URLAPI).Result;

                if (response.IsSuccessStatusCode)
                {
                    festivos = response.Content.ReadFromJsonAsync<HolidaysEntities>().Result;
                    int contador = 0;

                    foreach (Holiday a in festivos.Response.Holidays)
                    {
                        int anio = a.Date.Datetime.Year;
                        int mes = a.Date.Datetime.Month;
                        int dia = a.Date.Datetime.Day;

                        if(contador == 0)
                        {
                           await _db.EliminarFestivos();
                            contador = 1;
                        }

                        DynamicParameters parametros = new DynamicParameters();
                        DateTime fecha = new DateTime(anio, mes, dia);
                        parametros.Add("@Fecha", fecha);|
                        await _db.GuardarFestivos(parametros);
                    }

                    return new ResponseE<HolidaysEntities> 
                    {
                        isSuccess = true,
                        result = festivos,
                        message = "Se consultaron los festivos correctamente y guardaron los festivos correctamente"
                    };
                }
                else
                {
                    return new ResponseE<HolidaysEntities>
                    {
                        isSuccess = false,
                        message = "No se consultaron los festivos, ocurrio un error."
                    };
                }
            }
        }
    }
}
