using Microsoft.EntityFrameworkCore;
using PI_DigitalHouse_API_MVC.Models;

namespace PI_DigitalHouse_API_MVC.Models
{
    public class MeuPetContext : DbContext
    {
        public MeuPetContext(DbContextOptions<MeuPetContext> options) : base(options)
        {
        }
       
        public DbSet<CadastroPet> CadastroPets { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<CadastroUsuario>()
        //        .ToTable("Usuários")
        //        .HasKey(t => t.Id);

        //    modelBuilder.Entity<CadastroPet>()
        //        .ToTable("Alunos")
        //        .HasKey(t => t.Id);

        //    modelBuilder.Entity<CadastroUsuario>()
        //        .HasMany(t => t.Pets);

        //}
        protected override void OnConfiguring(DbContextOptionsBuilder Configuracao)
        {
            //Configuracao.UseInMemoryDatabase("MeuPet");
            Configuracao.UseSqlServer(@"Data Source = ME003391\SQLEXPRESS; Initial Catalog = MeuPet;Integrated Security = True; Connect Timeout = 30; Encrypt=False; TrustServerCertificate=False; ApplicationIntent=ReadWrite; MultiSubnetFailover=False");
        }
        public DbSet<CadastroUsuario> CadastroUsuarios { get; set; }
        public DbSet<PerdiMeuPet> PerdiMeusPets { get; set; }
        public DbSet<AcheiPet> AcheiPet { get; set; }
    }
}
