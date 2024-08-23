namespace CalcularFestivos.Entities.Configuration
{
    public class ResponseE<T>
    {
        public bool? isSuccess {  get; set; }
        public T? result {  get; set; }
        public string? message {  get; set; }
    }
}
