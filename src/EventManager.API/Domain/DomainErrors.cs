using EventManager.API.Common;

namespace EventManager.API.Domain
{
    public static class DomainErrors
    {
        public static Error NotFound(string id, string domainModelName) =>
            Error.NotFound($"{domainModelName}.NotFound", $"The {domainModelName} with the Id = '{id}' was not found");

        public static Error NotFound<T>(string id)
        {
            var typeName = typeof(T).Name.ToLower();
            return NotFound(id, typeName);
        }
    }
}
