namespace EventManager.API.Domain
{
    public class Event : DomainBaseEntity
    {
        public DateTime DateTime { get; set; }
        public string Agenda { get; set; } = default!;
        public bool IsSpeakerActive { get; set; }
        public Topic Topic { get; set; } = new();
        public User Speaker { get; set; } = new();
        
        private readonly List<Guid> userIds = new();
        public IReadOnlyCollection<Guid>? UserIds => userIds;

        public static Event Create(DateTime dateTime, 
            string agenda,
            IEnumerable<Guid>? userIds = null,
            bool isSpeakerActive = true,
            Topic? topic = null, 
            User? user = null) 
        {
            return new Event()
            {
                Id = Guid.NewGuid(),
                DateTime = dateTime, 
                Agenda = agenda,
                IsSpeakerActive = isSpeakerActive,
                Topic = topic ?? new Topic(),
                Speaker = user ?? new User()
            };
        }
    }
}
