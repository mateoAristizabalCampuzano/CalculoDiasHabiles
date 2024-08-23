namespace CalcularFestivos.Entities.Configuration
{
    public class AppConfiguration
    {
        public static string? ApiImplementacionExponencial { get; private set; }

        public static void Initialize(IConfiguration configuration)
        {
            ApiImplementacionExponencial = configuration["ApiUrls:ApiImplementacionExponencial"];
        }
    }
}
