namespace EventManager.API.Common
{
    public enum ErrorType
    {
        None = 0,
        Failure = 1,
        NotFound = 2,
        Validation = 3,
    }

    public class Error
    {
        public Error(string code, string description, ErrorType type)
        {
            Code = code;
            Description = description;
            Type = type;
        }

        public string Code { get; }
        public string Description { get; }
        public ErrorType Type { get; }

        public static readonly Error None = new(string.Empty, string.Empty, ErrorType.None);
        
        public static Error NotFound(string code, string description) =>
            new(code, description, ErrorType.NotFound);

        public static Error Failure(string code, string description) =>
            new(code, description, ErrorType.Failure);

        public static readonly Error NullValue = new("General.Null", "Null value was provided", ErrorType.Failure);
    }
}
