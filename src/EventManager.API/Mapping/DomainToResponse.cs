using EventManager.API.Domain;
using EventManager.API.Responses;

namespace EventManager.API.Mapping
{
    public static class DomainToResponse
    {
        public static void From(this UserResponse response, User domain)
        {
            response.Id = domain.Id.ToString();
            response.FirstName = domain.FirstName;
            response.LastName = domain.LastName;
            response.Position = domain.Position;
            response.Company = domain.Company;
            response.YearsOfExperience = domain.YearsOfExperience;
            response.Role = domain.Role.ToString();
        }

        public static void From(this TopicResponse response, Topic domain)
        {
            response.Id = domain.Id.ToString();
            response.IsActive = domain.IsActive;
            response.Name = domain.Name;
            response.Description = domain.Description;
        }

        public static void From(this EventResponse response, Event domain)
        {
            response.Id = domain.Id.ToString();
            response.SpeakerFirstName = domain.Speaker.FirstName;
            response.SpeakerLastName = domain.Speaker.LastName;
            response.SpeakerPosition = domain.Speaker.Position;
            response.SpeakerCompany = domain.Speaker.Company;
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
            return topics.Select(domain =>
            {
                var response = new TopicResponse();
                response.From(domain);
                return response;
            }).ToList();
        }

        public static List<UserResponse> ToResponses(this IEnumerable<User> users)
        {
            return users.Select(domain =>
            {
                var response = new UserResponse();
                response.From(domain);
                return response;
            }).ToList();
        }

        public static List<EventResponse> ToResponses(this IEnumerable<Event> events)
        {
            return events.Select(domain =>
            {
                var response = new EventResponse();
                response.From(domain);
                return response;
            }).ToList();
        }
    }
}
