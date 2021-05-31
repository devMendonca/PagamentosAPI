using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Pagamentos.Models
{
    public class PagamentosContext : DbContext
    {
        public PagamentosContext () : base("PagamentosConnection")
        {

        }

        public DbSet<Cartao> Cartoes { get; set; }
        public DbSet<Fatura> Faturas { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cartao>().ToTable("TBCartoes");
            modelBuilder.Entity<Cartao>().Property(p => p.NumeroCartao).IsRequired();
            modelBuilder.Entity<Cartao>().Property(p => p.Limite).IsRequired();
            modelBuilder.Entity<Fatura>().ToTable("TBFaturas");
            modelBuilder.Entity<Fatura>().Property(p => p.NumeroCartao).IsRequired().HasMaxLength(16);
            modelBuilder.Entity<Fatura>().Property(p => p.NumeroPedido).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Fatura>().Property(p => p.Valor).IsRequired();
        }


    }
}