namespace AcademyManager.Shared.Results
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public string? ErrorMessage { get; }
        public int? ErrorCode { get; }
        public T? Value { get; }

        protected Result(bool isSuccess, T? value, string? errorMessage, int? errorCode)
        {
            IsSuccess = isSuccess;
            Value = value;
            ErrorMessage = errorMessage;
            ErrorCode = errorCode;
        }

        public static Result<T> Success(T value) =>
            new(true, value, null, 200);

        public static Result<T> Failure(string errorMessage, int? errorCode = 400) =>
            new(false, default, errorMessage, errorCode);
    }
}
