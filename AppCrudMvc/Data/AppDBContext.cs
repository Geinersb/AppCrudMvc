using Microsoft.EntityFrameworkCore;
using AppCrudMvc.Models;


namespace AppCrudMvc.Data
{

    //aqui se define el contexto de la base de datos

    public class AppDBContext : DbContext
    {
        //esto es el constructor de la clase que recibe las opciones de configuracion de la base de datos
        //aqui vengo de Program.cs y ya tengo la cadena de conexion
        public AppDBContext(DbContextOptions<AppDBContext>options) : base(options)
        {
            
        }


        //aqui se define la tabla empleados que se va a utilizar en la base de datos

        public DbSet<Empleado> Empleados { get; set; }

        //esto nos ayuda a configurar el modelo de datos, solo escribo override y luego OnModelCreating y luego tab tab
        //no permite definir las caracteristicas de las tablas y relaciones entre ellas

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Empleado>(tb =>
            {
                //aqui defio la clave primaria
                tb.HasKey(col => col.IdEmpleado);
                //aqui defino que la columna IdEmpleado es autoincrementable
                tb.Property(col => col.IdEmpleado)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();
                //aqui defino que la columna NombreCompleto y tiene un maximo de 50 caracteres
                tb.Property(col => col.NombreCompleto).HasMaxLength(50);
                //aqui defino que la columna correo y tiene un maximo de 50 caracteres
                tb.Property(col => col.correo).HasMaxLength(50);
            });

            //esto lo que hace es que la tabla se llame Empleado y no Empleados, es decir puedo definir el nombre de la tabla aunque clase se llame diferente
            modelBuilder.Entity<Empleado>().ToTable("Empleado");

        }

        //para crear la base de datos voy a la consola del administrador de paquetes y escribo
        //Add-Migration "nombre de migracion"
        //Update-Database
        //con esto se crea la base de datos y la tabla empleados

    }
}
