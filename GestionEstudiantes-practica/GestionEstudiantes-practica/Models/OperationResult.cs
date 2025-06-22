public class OperationResult
{
    public string Message { get; set; }
    public bool Success { get; set; }
    public object Data { get; set; }

    public OperationResult(bool success, string message, object data = null)
    {
        Success = success;
        Message = message;
        Data = data;
    }
}