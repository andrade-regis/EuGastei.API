namespace EuGastei.Application.Common.Results;

public class Result<T>
{
    public bool Success { get; private set; }
    public string Message { get; private set; }
    public T Data { get; private set; }
    public IEnumerable<string> Errors { get; private set; }

    private Result() { }

    public Result(T data, 
                  string message = null)
    {
        Success = true;
        Message = message;
        Data = data;
        Errors = null;
    }

    public Result(IEnumerable<string> errors, 
                  string message = null)
    {
        Success = false;
        Message = message;
        Errors = errors;
        Data = default;
    }

    public Result(Exception exception)
    {
        Success = false;
        Message = exception.Message;
        Errors = new[] { exception.Message };
        Data = default;
    }
}