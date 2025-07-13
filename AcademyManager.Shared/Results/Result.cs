namespace AcademyManager.Shared.Results
{
    public class Result
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public string? ErrorMessage { get; }
        public int ErrorCode { get; }

        private Result(bool isSuccess, string? errorMessage, int errorCode)
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
            ErrorCode = errorCode;
        }

        public static Result Success() =>
            new (true, null, 200);

        public static Result Failure(string errorMessage, int errorCode = 400) =>
            new (false, errorMessage, errorCode);
    }

}
