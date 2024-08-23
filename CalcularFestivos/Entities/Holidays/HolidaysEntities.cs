using Newtonsoft.Json;

namespace CalcularFestivos.Entities.Holidays
{
    public class HolidaysEntities
    {
        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        [JsonProperty("response")]
        public Response Response { get; set; }
    }

    public class Meta
    {
        [JsonProperty("code")]
        public int Code { get; set; }
    }

    public class Country
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Datetime
    {
        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("month")]
        public int Month { get; set; }

        [JsonProperty("day")]
        public int Day { get; set; }
    }

    public class Date
    {
        [JsonProperty("iso")]
        public string Iso { get; set; }

        [JsonProperty("datetime")]
        public Datetime Datetime { get; set; }
    }

    public class Holiday
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("country")]
        public Country Country { get; set; }

        [JsonProperty("date")]
        public Date Date { get; set; }

        [JsonProperty("type")]
        public List<string> Type { get; set; }

        [JsonProperty("primary_type")]
        public string PrimaryType { get; set; }

        [JsonProperty("canonical_url")]
        public string CanonicalUrl { get; set; }

        [JsonProperty("urlid")]
        public string Urlid { get; set; }

        [JsonProperty("locations")]
        public string Locations { get; set; }

        [JsonProperty("states")]
        public string States { get; set; }
    }

    public class Response
    {
        [JsonProperty("holidays")]
        public List<Holiday> Holidays { get; set; }
    }
}
