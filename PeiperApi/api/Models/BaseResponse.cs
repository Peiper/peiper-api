namespace api.Models
{
    public class BaseResponse<T>
    {
        public T Result { get; set; }
        public BaseResponse(T value)
        {
            Result = value;
        }
    }
}
