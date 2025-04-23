using EventManager.API.Domain;
using EventManager.API.Requests;

namespace EventManager.API.Mapping
{
    public static class DomainToRequest
    {
        public static void ToRequest(this Event domain, EventRequest request)
        {
            request.DateTime = domain.DateTime;
            request.SpeakerId = domain.SpeakerId.ToString();
            request.TopicId = domain.TopicId.ToString();
        }

        public static void ToRequest(this Topic domain, TopicRequest request)
        {
            request.Description = domain.Description;
            request.Name = domain.Name;
        }

        public static void ToRequest(this User domain, UserRequest request)
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
