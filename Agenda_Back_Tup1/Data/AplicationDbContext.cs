using Agenda_Back_Tup.Entities;
using Agenda_Back_Tup1.Entities;
using Microsoft.EntityFrameworkCore;

namespace Agenda_Back_Tup1.Data
{
    public class AplicationDbContext: DbContext 
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options) //constructor para inyeccion de dbcontext
        {

        }


        public DbSet<Contacto> Contactos { get; set; }
        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AgendasUsers> AgendasUsers { get; set; } //creacion de las tablas de la db

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //definfimos nuestra PK

            builder.Entity<AgendasUsers>().HasKey(au => new { au.AgendaId, au.UserId }); //Pk compuesta de la tabla agendasusers

            //definimos las relaciones entre tablas
            builder.Entity<AgendasUsers>().HasOne<Agenda>(au => au.Agenda).WithMany(a => a.AgendasUsers).HasForeignKey(au => au.AgendaId);

            builder.Entity<AgendasUsers>().HasOne<User>(au => au.User).WithMany(u => u.AgendasUsers).HasForeignKey(au => au.UserId);
        }
    }
}
