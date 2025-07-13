namespace AcademyManager.Shared.Results
{
    public class ResultT<T>
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public string? ErrorMessage { get; }
        public T? Value { get; }

        private ResultT(bool isSuccess, T? value, string? errorMessage)
        {
            IsSuccess = isSuccess;
            Value = value;
            ErrorMessage = errorMessage;
        }

        public static ResultT<T> Success(T value) =>
            new (true, value, null);

        public static ResultT<T> Failure(string errorMessage) =>
            new (false, default, errorMessage);
    }
}
