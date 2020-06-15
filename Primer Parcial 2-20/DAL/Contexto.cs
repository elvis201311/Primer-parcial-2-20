using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Primer_Parcial_2_20.Entidades;

namespace Primer_Parcial_2_20.DAL
{
   public class Contexto : DbContext 
    {
        public DbSet<Articulos> Articulos{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuider)
        {
            optionsBuider.UseSqlite(@"Data source = Data\Usuarios.db");
        }
    }
    
    
}
