using ApiUsuarios.Domain.Entities;
using ApiUsuarios.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Infra.Data.Contexts
{
    /// <summary>
    /// Classe de contexto para conexão com o banco de dados
    /// </summary>
    public class DataContext : DbContext
    {
        //método para conexao com banco de dados ou InMemory
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "BD_ApiUsuarios");
            //optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BD_ApiProdutos;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        
        // Método para adicionarmos as classes de mapeamento do projeto  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }


        // Propriedades para forneces os métodos de CRUD para Usuario
        public DbSet<Usuario> Usuario { get; set; }


    }
}
