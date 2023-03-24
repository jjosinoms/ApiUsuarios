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
        //método para conexão com o banco de dados ou InMemory
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemoryDatabase(databaseName: "BD_ApiUsuarios");
            optionsBuilder.UseSqlServer(@"Data Source=SQL5101.site4now.net;Initial Catalog=db_a96272_bdapiusuarios;User Id=db_a96272_bdapiusuarios_admin;Password=coti1234");
        }

        //método para adicionarmos as classes de mapeamento
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }

        //Propriedade DbSet para cada entidade (CRUD)
        public DbSet<Usuario> Usuario { get; set; }
    }
}
