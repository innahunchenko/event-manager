namespace EventManager.API.Requests
{
    public class AssignEventsRequest
    {
        public IEnumerable<string> EventIds { get; set; } = new List<string>();
    }
}
