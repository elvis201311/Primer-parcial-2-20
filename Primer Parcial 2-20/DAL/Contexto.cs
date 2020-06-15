using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Primer_Parcial_2_20.DAL
{
   public class Contexto : DbContext 
    {
        public DbSet<Entidades.Usuarios> Usuarios { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuider)
        {
            optionsBuider.UseSqlite(@"Data source = Data\Usuarios.db");
        }
    }
}
