using Microsoft.EntityFrameworkCore;
using Videos.Domain.Entities;

namespace Videos.Infrastructure;

public class VideosDbContext : DbContext
{
    public VideosDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Video>  Videos { get; set; }
}