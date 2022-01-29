namespace Chat.Domain;

public class ChatRoom
{
    public Guid Id { get; set; }
    public Guid RecruiterId { get; set; }
    public Guid DeveloperId { get; set; }
    public ICollection<Message> Messages { get; set; } = new List<Message>();
}