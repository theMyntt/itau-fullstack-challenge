namespace Presentations.Models
{
    public class ClientModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Participation { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
