
using EFPlatzi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFPlatzi.Models
{
    public class Tarea
    {
        //[Key]
        public Guid TareaId { get; set; }
        //[ForeignKey("CategoriaId")]
        public Guid CategoriaId { get; set; }
        //[Required]
        //[MaxLength(200)]
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public prioridad PrioridadTarea { get; set; }
        public DateTime FechaCreacion { get; set; }


        public virtual Categoria Categoria { get; set; }

        //[NotMapped]
        public string Resumen { get; set; }


    }

    public enum prioridad
    {
        baja,
        media,
        alta
    }
}
