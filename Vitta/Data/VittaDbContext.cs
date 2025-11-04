using Microsoft.EntityFrameworkCore;
using Vitta.Models; // Importa sua entidade Usuario

namespace Vitta.Data {
    public class VittaDbContext : DbContext {
        // Construtor que recebe as opções de configuração (como a connection string)
        public VittaDbContext(DbContextOptions<VittaDbContext> options) : base(options) {
        }

        // Mapeia a classe Usuario para uma tabela "TB_USUARIO" no banco
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            // Define o nome da tabela e o schema (se necessário)
            modelBuilder.Entity<Usuario>().ToTable("TB_USUARIO");

            // Mapeia a propriedade Id para a coluna "ID_USUARIO" e a define como chave primária
            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Id)
                .HasColumnName("ID_USUARIO");

            // Mapeia as outras propriedades
            modelBuilder.Entity<Usuario>()
                .Property(u => u.Nome)
                .HasColumnName("NM_USUARIO")
                .IsRequired();

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Email)
                .HasColumnName("DS_EMAIL")
                .IsRequired();

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Objetivo)
                .HasColumnName("DS_OBJETIVO");
        }
    }
}