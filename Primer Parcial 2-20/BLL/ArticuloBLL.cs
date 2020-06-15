using Microsoft.EntityFrameworkCore;
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

        public class UsuariosBLL
        {
            //Metodo Existe
            public static bool Existe(int Id)
            {
                Contexto contexto = new Contexto();
                bool encontrado = false;

                try
                {
                    encontrado = contexto.Articulos.Any(encontrado => encontrado.ProductoId == Id);
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

            //Metodo Insertar 
            private static bool Insertar(Entidades.Articulos Articulo)
            {
                bool key = false;
                Contexto contexto = new Contexto();

                try
                {
                    contexto.Articulos.Add(Articulo);
                    key = contexto.SaveChanges() > 0;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    contexto.Dispose();
                }
                return key;
            }

            //Metodo Modificar.
            private static bool Modificar(Entidades.Articulos usuarios)
            {
                bool key = false;
                Contexto contexto = new Contexto();

                try
                {
                    contexto.Entry(usuarios).State = EntityState.Modified;
                    key = contexto.SaveChanges() > 0;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    contexto.Dispose();
                }

                return key;
            }

            //Metodo Guardar.
            public static bool Guardar(Entidades.Articulos usuarios)
            {
                if (!Existe(usuarios.ProductoId))
                {
                    return Insertar(usuarios);
                }
                else
                {
                    return Modificar(usuarios);
                }
            }

            private static bool Existe(object usuarioId)
            {
                throw new NotImplementedException();
            }

            //Metodo Eliminar.
            public static bool Eliminar(int Id)
            {
                bool key = false;
                Contexto contexto = new Contexto();

                try
                {
                    var usuarios = contexto.Articulos.Find(Id);

                    if (usuarios != null)
                    {
                        contexto.Articulos.Remove(usuarios);
                        key = contexto.SaveChanges() > 0;
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

                return key;
            }

            //Metodo Buscar.
            public static Entidades.Articulos Buscar(int Id)
            {
                Contexto contexto = new Contexto();
                Entidades.Articulos usuarios;

                try
                {
                    usuarios = contexto.Articulos.Find(Id);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    contexto.Dispose();
                }

                return usuarios;
            }

            //Metodo Lista.
            public static List<Entidades.Articulos> GetList(Expression<Func<Entidades.Articulos, bool>> criterio)
            {
                List<Entidades.Articulos> lista = new List<Entidades.Articulos>();
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
        }
    }
}