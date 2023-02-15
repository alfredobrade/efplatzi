using EFPlatzi.Models;
using Microsoft.EntityFrameworkCore;

namespace EFPlatzi
{
    public class TareasContext : DbContext //heredamos de la libreria para contexto
    {
        //ahora vamos a crear un DB-Set (tabla?)
        public DbSet<Categoria> Categoria { get; set; }
        //aca lo mismo
        public DbSet<Tarea> Tarea { get; set; }

        // constructor de EF 
        public TareasContext(DbContextOptions<TareasContext> options) : base(options) { } //TODO: esto no entendi un carajo- constructor de EF-v8m4:30


        //aca empezamos a usar FLUENT API
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Categoria>(categoria =>
            {
                //categoria.ToTable("Categoria");
                categoria.HasKey(p => p.CategoriaId);
                //categoria.Property(i => i.CategoriaId).UseIdentityColumn();
                categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
                categoria.Property(p => p.Descripcion);
                categoria.Property(p => p.Peso);

            });
            modelBuilder.Entity<Tarea>(tarea =>
            {
                tarea.ToTable("Tarea");
                tarea.HasKey(p => p.TareaId);
                //tarea.Property(p => p.TareaId).UseIdentityColumn();
                tarea.HasOne(p => p.Categoria).WithMany(c => c.Tareas).HasForeignKey(p => p.CategoriaId);
                //tarea.HasOne<Categoria>(p => p.Categoria);
                tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
                tarea.Property(p => p.Descripcion);
                tarea.Property(p => p.PrioridadTarea);
                tarea.Property(p => p.FechaCreacion);
                //no le agregamos en property y con eso ya no se agrega a la base datos
                tarea.Ignore(p => p.Resumen);

                
            });

        }


        
    }
}
