using EventManager.API.Domain;
using EventManager.API.Requests;

namespace EventManager.API.Mapping
{
    public static class DomainToRequest
    {
        public static void From(this EventRequest request, Event domain)
        {
            request.DateTime = domain.DateTime;
            request.SpeakerId = domain.SpeakerId.ToString();
            request.TopicId = domain.TopicId.ToString();
        }

        public static void From(this TopicRequest request, Topic domain)
        {
            request.Description = domain.Description;
            request.Name = domain.Name;
        }

        public static void From(this UserRequest request, User domain)
        {
            request.FirstName = domain.FirstName;
            request.LastName = domain.LastName;
            request.Company = domain.Company;
            request.Position = domain.Position;
            request.YearsOfExperience = domain.YearsOfExperience;
            request.Role = domain.Role.ToString();
        }
    }
}
