using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sistema_Cetmar.Models
{
    public class Alumno
    {
        [Key]
        public int alumnoID { get; set; }

        [Required, Display(Name = "No. Expediente")]
        public int noExpediente { get; set; }

        [Required, Display(Name = "Número de Control")]
        public int alumnoNumeroControl { get; set; }

        [Required, Display(Name = "Nombre Paciente")]
        public string nombreAlumno { get; set; }

        [Required, Display(Name = "Apellido Paterno")]
        public string apellidoPatAlumno { get; set; }

        [Required, Display(Name = "Apellido Materno")]
        public string apellidoMatAlumno { get; set; }

        [Required, Display(Name = "Fecha de Nacimiento")]
        public string fechaNac { get; set; }

        [Required, Display(Name = "Teléfono")]
        public string telefonoAlumno { get; set; }

        [Required, Display(Name = "Domicilio")]
        public string domicilioAlumno { get; set; }

        [Required, Display(Name = "Grupo")]
        public string grupoAlumno { get; set; }

        //Enlace a la tabla de Expediente
        virtual public ICollection<Expediente> expedientes { get; set; }
    }
}