using Chat.Domain;
using Microsoft.EntityFrameworkCore;

namespace Chat.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public DbSet<ChatRoom> Chats { get; set; }
    public DbSet<Message> Messages { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}