﻿using Microsoft.EntityFrameworkCore;
using Primer_Parcial_2_20.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Primer_Parcial_2_20.Entidades;
namespace Primer_Parcial_2_20.BLL
{
    public class ArticuloBLL
    {

        public static bool Guardar(Articulos articulos)
        {
            if (!Existe(articulos.ProductoId))
                return Insertar(articulos);
            else
                return Modificar(articulos);
        }

        private static bool Insertar(Articulos articulos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Articulos.Add(articulos);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Articulos articulos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(articulos).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var articulos = contexto.Articulos.Find(id);
                if (articulos != null)
                {
                    contexto.Articulos.Remove(articulos);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static Articulos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Articulos articulos;
            try
            {
                articulos = contexto.Articulos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return articulos;
        }
 
        public static List<Articulos> GetList(Expression<Func<Articulos, bool>> criterio)
        {
            List<Articulos> lista = new List<Articulos>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Articulos.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Articulos.Any(d => d.ProductoId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }
        public static List<Articulos> GetArticulos()
        {
            List<Articulos> lista = new List<Articulos>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Articulos.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}