namespace EventManager.API.Requests
{
    public class AssignEventsRequest : IRequest
    {
        public string Id { get; set; } = "";
        public IEnumerable<string> EventIds { get; set; } = new List<string>();
    }
}
