using EventManager.API.Domain;
using EventManager.API.Responses;

namespace EventManager.API.Mapping
{
    public static class DomainToResponse
    {
        public static void ToResponse(this User domain, UserResponse response)
        {
            response.Id = domain.Id.ToString();
            response.FirstName = domain.FirstName;
            response.LastName = domain.LastName;
            response.Position = domain.Position;
            response.Company = domain.Company;
            response.YearsOfExperience = domain.YearsOfExperience;
            response.Role = domain.Role.ToString();
        }

        public static void ToResponse(this Topic domain, TopicResponse response)
        {
            response.Id = domain.Id.ToString();
            response.IsActive = domain.IsActive;
            response.Name = domain.Name;
            response.Description = domain.Description;
        }

        public static void ToResponse(this Event domain, EventResponse response)
        {
            response.Id = domain.Id.ToString();
            response.SpeakerFirstName = domain.Speaker.FirstName;
            response.SpeakerLastName = domain.Speaker.LastName;
            response.SpeakerPosition = domain.Speaker.Position;
            response.SpeakerCompany = domain.Speaker.Company;
            response.IsSpeakerActive = domain.IsSpeakerActive;
            response.TopicName = domain.Topic.Name;
            response.DateTime = domain.DateTime;
        }

        //public static List<TResponse> ToResponses<TDomain, TResponse>(
        //    this IEnumerable<TDomain> domains, Action<TDomain, TResponse> map) where TResponse : new()
        //{
        //    return domains.Select(d =>
        //    {
        //        var response = new TResponse();
        //        map(d, response);
        //        return response;
        //    }).ToList();
        //}

        public static List<TopicResponse> ToResponses(this IEnumerable<Topic> topics)
        {
            return topics.Select(t =>
            {
                var response = new TopicResponse();
                t.ToResponse(response);
                return response;
            }).ToList();
        }

        public static List<UserResponse> ToResponses(this IEnumerable<User> users)
        {
            return users.Select(d =>
            {
                var response = new UserResponse();
                d.ToResponse(response);
                return response;
            }).ToList();
        }

        public static List<EventResponse> ToResponses(this IEnumerable<Event> events)
        {
            return events.Select(d =>
            {
                var response = new EventResponse();
                d.ToResponse(response);
                return response;
            }).ToList();
        }
    }
}
