namespace aspnet_mvc.Models
{
    public class ErrorViewModel<T>where T : class , new()
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string Result { get; set; }
        public List<T> Entities { get; set; }
    }
}