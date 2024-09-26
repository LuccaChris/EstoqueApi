using Microsoft.EntityFrameworkCore;

public class MeubancoCtx : DbContext
{
    public MeubancoCtx(DbContextOptions<MeubancoCtx> options) : base(options) { }

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Fornecedor> Fornecedores { get; set; }
    public DbSet<Estoque> Estoques { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuração das relações
        modelBuilder.Entity<Produto>()
            .HasOne(p => p.Fornecedor)
            .WithMany(f => f.Produtos)
            .HasForeignKey(p => p.IdFornecedor);

        modelBuilder.Entity<Estoque>()
            .HasOne(e => e.Produto)
            .WithMany()
            .HasForeignKey(e => e.IdProduto);
    }
}

