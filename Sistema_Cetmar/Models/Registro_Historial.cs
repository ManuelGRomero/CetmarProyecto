using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sistema_Cetmar.Models
{
    public class Registro_Historial
    {
        [Key]
        public int registroHistorialID { get; set; }
        [Required, Display(Name = "Nota")]
        public string registroHistorialnota { get; set; }
        [Required, Display(Name = "Fecha Realizada"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), DataType(DataType.Date)]
        public DateTime registroHistorialFecha { get; set; }
        [Required, Display(Name = "Canalización")]
        public string registroHistorialCanalizacion { get; set; }

        //Enlace a la tabla de Expedientes
        [Required, Display(Name = "Expediente Alumno")]
        public int expedianteID { get; set; }


        public virtual Expediente expedientes { get; set; }
    }
}