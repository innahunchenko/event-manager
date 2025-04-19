namespace EventManager.API.Domain
{
    public class Event : IEntity
    {
        public DateTime DateTime { get; set; }
        public bool IsSpeakerActive { get; set; }
        public Topic Topic { get; set; } = new();
        public User Speaker { get; set; } = new();

        public static Event Create(DateTime dateTime, 
                                    Topic topic,
                                    User speaker,
                                    bool isSpeakerActive = true) 
        {
            return new Event()
            {
                Id = Guid.NewGuid(),
                DateTime = dateTime, 
                IsSpeakerActive = isSpeakerActive,
                Topic = topic ,
                Speaker = speaker
            };
        }
    }
}
