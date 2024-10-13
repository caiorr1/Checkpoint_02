using CP2.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CP2.Data.AppData
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<FornecedorEntity> Fornecedor { get; set; }
        public DbSet<VendedorEntity> Vendedor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração da entidade Fornecedor
            modelBuilder.Entity<FornecedorEntity>(entity =>
            {
                entity.ToTable("tb_fornecedor");

                entity.HasKey(e => e.Id); // Definindo a chave primária

                entity.Property(e => e.Nome)
                      .IsRequired()
                      .HasMaxLength(100); // Campo Nome é obrigatório e tem um tamanho máximo de 100 caracteres

                entity.Property(e => e.CNPJ)
                      .IsRequired()
                      .HasMaxLength(14); // Campo CNPJ é obrigatório e tem um tamanho máximo de 14 caracteres

                entity.Property(e => e.Telefone)
                      .HasMaxLength(15); // Definindo um tamanho máximo para o campo Telefone

                entity.Property(e => e.Email)
                      .HasMaxLength(100); // Definindo um tamanho máximo para o campo Email

                entity.Property(e => e.CriadoEm)
                      .IsRequired(); // Campo CriadoEm é obrigatório
            });

            // Configuração da entidade Vendedor
            modelBuilder.Entity<VendedorEntity>(entity =>
            {
                entity.ToTable("tb_vendedor");

                entity.HasKey(e => e.Id); // Definindo a chave primária

                entity.Property(e => e.Nome)
                      .IsRequired()
                      .HasMaxLength(100); // Campo Nome é obrigatório e tem um tamanho máximo de 100 caracteres

                entity.Property(e => e.Email)
                      .IsRequired()
                      .HasMaxLength(100); // Campo Email é obrigatório e tem um tamanho máximo de 100 caracteres

                entity.Property(e => e.Telefone)
                      .HasMaxLength(15); // Definindo um tamanho máximo para o campo Telefone

                entity.Property(e => e.DataNascimento)
                      .IsRequired(); // Campo DataNascimento é obrigatório

                entity.Property(e => e.Endereco)
                      .HasMaxLength(200); // Definindo um tamanho máximo para o campo Endereço

                entity.Property(e => e.DataContratacao)
                      .IsRequired(); // Campo DataContratacao é obrigatório

                entity.Property(e => e.ComissaoPercentual)
                      .HasColumnType("decimal(5,2)"); // Percentual de comissão com duas casas decimais

                entity.Property(e => e.MetaMensal)
                      .HasColumnType("decimal(10,2)"); // Meta mensal com duas casas decimais

                entity.Property(e => e.CriadoEm)
                      .IsRequired(); // Campo CriadoEm é obrigatório
            });
        }
    }
}
