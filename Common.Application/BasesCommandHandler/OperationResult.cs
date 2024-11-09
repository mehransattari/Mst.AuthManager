namespace Common.Application.BasesCommandHandler;
public class OperationResult
{
    #region Properties

    public const string SuccessMessage = "عملیات با موفقیت انجام شد";
    public const string ErrorMessage = "عملیات با شکست مواجه شد";
    public const string NotFoundMessage = "اطلاعات یافت نشد";

    public string Message { get; set; }

    public string? Title { get; set; } = null;

    public OperationResultStatus Status { get; set; }

    #endregion

    #region Methods
    public static OperationResult Error()
    {
        return new OperationResult()
        {
            Status = OperationResultStatus.Error,
            Message = ErrorMessage,
        };
    }
    public static OperationResult NotFound(string message)
    {
        return new OperationResult()
        {
            Status = OperationResultStatus.NotFound,
            Message = message,
        };
    }
    public static OperationResult NotFound()
    {
        return new OperationResult()
        {
            Status = OperationResultStatus.NotFound,
            Message = NotFoundMessage,
        };
    }
    public static OperationResult Error(string message)
    {
        return new OperationResult()
        {
            Status = OperationResultStatus.Error,
            Message = message,
        };
    }
    public static OperationResult Error(string message, OperationResultStatus status)
    {
        return new OperationResult()
        {
            Status = status,
            Message = message,
        };
    }
    public static OperationResult Success()
    {
        return new OperationResult()
        {
            Status = OperationResultStatus.Success,
            Message = SuccessMessage,
        };
    }
    public static OperationResult Success(string message)
    {
        return new OperationResult()
        {
            Status = OperationResultStatus.Success,
            Message = message,
        };
    }
    #endregion
}

public class OperationResult<TData>
{
    #region Properties

    public const string SuccessMessage = "عملیات با موفقیت انجام شد";
    public const string ErrorMessage = "عملیات با شکست مواجه شد";

    public string Message { get; set; }

    public string? Title { get; set; } = null;

    public OperationResultStatus Status { get; set; }

    public TData? Data { get; set; }

    #endregion

    #region Methods
    public static OperationResult<TData> Success(TData data)
    {
        return new OperationResult<TData>()
        {
            Status = OperationResultStatus.Success,
            Message = SuccessMessage,
            Data = data,
        };
    }

    public static OperationResult<TData> NotFound()
    {
        return new OperationResult<TData>()
        {
            Status = OperationResultStatus.NotFound,
            Title = "NotFound",
            Data = default,
        };
    }

    public static OperationResult<TData> Error(string message = ErrorMessage)
    {
        return new OperationResult<TData>()
        {
            Status = OperationResultStatus.Error,
            Title = "مشکلی در عملیات رخ داده",
            Data = default,
            Message = message
        };
    }
    #endregion
}
