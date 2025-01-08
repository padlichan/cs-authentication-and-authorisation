namespace ConferenceManager.Services;

public class Result<T>
{
    public Result(bool isSuccess, T? data = default, string? errorMessage = null)
    {
        IsSuccess = isSuccess;
        Data = data;
        ErrorMessage = errorMessage;
    }

    public bool IsSuccess { get; set; }
    public T? Data { get; set; }
    public string? ErrorMessage { get; set; }

    public static Result<T> Success(T data) => new Result<T>(true, data);
    public static Result<T> Error(string errorMessage) => new Result<T>(false, default, errorMessage);
}
