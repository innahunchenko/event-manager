namespace EventManager.API.Database.Models
{
    public class DbEntity
    {
        public string Id { get; init; } = default!;
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
