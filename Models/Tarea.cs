﻿
using EFPlatzi.Models;


namespace EFPlatzi.Models
{
    public class Tarea
    {
        public Guid TareaId { get; set; }
        public Guid CategoriaId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public prioridad PrioridadTarea { get; set; }
        public DateTime FechaCreacion { get; set; }


        public virtual Categoria Categoria { get; set; }


    }

    public enum prioridad
    {
        baja,
        media,
        alta
    }
}