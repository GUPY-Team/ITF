namespace Chat.Domain;

public class ChatRoom
{
    public Guid Id { get; set; }
    public Guid RecruiterId { get; set; }
    public Guid ApplicantId { get; set; }
    public ICollection<Message> Messages { get; set; } = new List<Message>();
}