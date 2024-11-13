using EGM.AracKiralama.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace EGM.AracKiralama.DAL.Context
{
    public class LogDbContext : DbContext
    {
        public LogDbContext(DbContextOptions<LogDbContext> options) : base(options)
        {
        }
        public virtual DbSet<LogTable> LogTable { get; set; }
    }
}
