using Infra.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.DAL.Context
{
    public class LogDbContext : DbContext
    {
        public LogDbContext(DbContextOptions<LogDbContext> options) : base(options)
        {
        }
        public virtual DbSet<LogTable> LogTable { get; set; }
        public virtual DbSet<ErrorLogTable> ErrorLogTable { get; set; }
    }
}
