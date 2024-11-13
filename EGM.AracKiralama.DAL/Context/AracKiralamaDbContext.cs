using EGM.AracKiralama.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace EGM.AracKiralama.DAL.Context
{
    public class AracKiralamaDbContext : DbContext
    {
        public AracKiralamaDbContext(DbContextOptions<AracKiralamaDbContext> options) : base(options)
        {
        }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<BrandModel> Model { get; set; } //Tablo ismiyle entity ismi aynı olmak zorunda değil.
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }
    }
}
