using Microsoft.EntityFrameworkCore;
namespace EjercicioClase3Modulo2EFCore
{
    internal class Program
    {
        static void Main( string[] args )
        {
            #region Pasos previos
            //Ejecutar el script de base de datos en Management Studio para crear la base de datos y la tabla con datos
            //Instalar Microsoft.EntityFrameworkCore y Microsoft.EntityFrameworkCore.SqlServer
            //Crear las entidades necesarias
            //Crear el dbcontext
            //Configurar aqui el connection string e instanciar el contexto de la base de datos.

            var options = new DbContextOptionsBuilder<BDContext>();
            options.UseSqlServer("Data Source=Elias;Initial Catalog=SimpleIMDB;Integrated Security=True;Encrypt=False");

            var context = new BDContext(options.Options);
            #endregion

            #region ejercicio 1
            //Obtener un listado de todos los actores y actrices de la tabla actor
            var result = context.Actor.ToList();

            #endregion

            #region ejercicio 2
            //Obtener listado de todas las actrices de la tabla actor
            var actrices = context.Actor.Where(actor => actor.Genero == "F");

            #endregion

            #region ejercicio 3
            //Obtener un listado de todos los actores y actrices mayores de 50 años de la tabla actor
            var actoresMayores = context.Actor.Where(actor => actor.Edad > 50);
            #endregion

            #region ejercicio 4
            //Obtener la edad de la actriz "Julia Roberts"
            var edadDeJuliaRoberts = context.Actor.Where(actor => actor.Nombre == "Julia" && actor.Apellido == "Roberts").Select(propa => propa.Edad).ToList();
            #endregion

            #region ejercicio 5
            //Insertar un nuevo actor en la tabla actor con los siguientes datos:
            //nombre: Ricardo
            //apellido: Darin
            //edad: 67 años
            //nombre_artistico: Ricardo Darin
            //nacionalidad: argentino
            //género: Masculino.

            Actor darin = new Actor() { Nombre = "Ricardo", Apellido = "Darin", Edad = 67, Nombre_artistico = "Ricardo Darin", Nacionalidad = "Argentino", Genero = "M" };
            context.Actor.Add(darin);

            context.SaveChanges();
            #endregion

            #region ejercicio 6
            //obtener la cantidad de actores y actrices que no son de Estados Unidos.
            var cantidadQueNoSonDeUsa = context.Actor.Where(actor => actor.Nacionalidad != "USA").ToList();
            #endregion

            #region ejercicio 7
            //obtener los nombres y apellidos de todos los actores maculinos.
            var masculinos = context.Actor.Where(actor => actor.Genero == "M").Select(p => new {p.Nombre, p.Apellido}).ToList();
            #endregion
         }
    }
}