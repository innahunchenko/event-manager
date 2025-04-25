namespace EventManager.API.Common
{
    public enum ErrorType
    {
        None = 0,
        Failure = 1,
        Validation = 2,
        Problem = 3,
        NotFound = 4,
        Conflict = 5
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
    }
}
