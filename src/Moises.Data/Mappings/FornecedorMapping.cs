using MinhaAppMvcCompleta.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Documento)
                .IsRequired()
                .HasColumnType("varchar(14)");

            //1 : 1 => Fornecedor : Endereco (relacionamento(1,1))
            builder.HasOne(f => f.Endereco)
                .WithOne(e => e.Fornecedor);

            //1 : n => Fornecedor : Produtos (relacionamento(1,n))
            builder.HasMany(f => f.Produtos)
                .WithOne(p => p.Fornecedor)
                    .HasForeignKey(p => p.FornecedorId);


            builder.ToTable("Fornecedores");
        }
    }
}
