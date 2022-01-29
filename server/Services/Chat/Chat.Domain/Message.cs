namespace Chat.Domain;

public class Message
{
    public Guid Id { get; set; }
    public Guid ChatId { get; set; }
    public Guid SenderId { get; set; }
    public ChatRoom Chat { get; set; }
    public DateTime Sent { get; set; }
    public string Content { get; set; }
    public bool Seen { get; set; }
}