namespace EventManager.API.Common
{
    public class Result
    {
        public Result(bool isSuccess, Error error) 
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; }

        public static Result<TValue> Failure<TValue>(Error error) =>
            new(default, false, error);

        public static Result<TValue> Success<TValue>(TValue value) =>
            new(value, true, Error.None);

        public static Result Failure(Error error) => new Result(false, error);
        
        public static Result Success() => new Result(true, Error.None);
    }

    public class Result<TValue> : Result
    {
        private readonly TValue value;
        public TValue Value => value;

        public Result(TValue value, bool isSuccess, Error error) : base(isSuccess, error)
        {
            this.value = value;
        }

        public static implicit operator Result<TValue>(TValue? value) =>
            value is not null ? Success(value) : Failure<TValue>(Error.NullValue);
    }
}