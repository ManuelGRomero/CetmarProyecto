using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sistema_Cetmar.Models
{
    public class Expediente
    {
        [Key]
        public int expedienteID { get; set; }


        [Display(Name = "Alumno")]
        public int alumnoID { get; set; }

        public virtual Alumno alumnos { get; set; }

        //Enlace a la tabla de Especialista
        [Required, Display(Name = "Especialista")]
        public int especialistaID { get; set; }

        public virtual Especialista especialistas { get; set; }

        //Enlace a la tabla de Registro_Historial
        virtual public ICollection<Registro_Historial> Registro { get; set; }
    }
}