using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD_CURSOS.Models.ViewModels
{
    public class AgregarCursos
    {
        [Required]
        [StringLength (50)]
        [Display (Name = "Nombre del curso")]
        public string Nombre_Cursos { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre de las materias")]
        public string Materias { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre del alumno")]
        public string Alumnos { get; set; }
    }
}