namespace EventManager.API.Requests
{
    public class AssignEventsRequest : IRequest
    {
        public string Id { get; set; } = string.Empty;
        public IEnumerable<string> EventIds { get; set; } = new List<string>();
    }
}
