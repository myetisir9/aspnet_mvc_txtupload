using AspEntity.Abstract;

namespace AspEntity.Concrete
{
    public class ErrorViewModel<T> :IEntity where T : class , new()
    {

        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string Result { get; set; }
        public List<T> Entities { get; set; }
    }
}